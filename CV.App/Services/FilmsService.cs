using AutoMapper;
using CV.App.Mapper;
using CV.App.Shared.Models;
using CV.Infrastructure;
using CV.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CV.App.Services
{
    public interface IFilmsService
    {
        Task<FilmDto> GetFilmInfo(int filmId);
        Task<IEnumerable<SearchResult>> GetSearchResultsAsync(string query);
    }

    public class FilmsService : IFilmsService
    {
        private readonly ApplicationDbContext _dbContext;

        public FilmsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FilmDto> GetFilmInfo(int filmId)
        {
            if (filmId <= 0)
            {
                return new FilmDto();
            }

            var film = await _dbContext.Films
                .Include(s => s.Screenshots)
                .Include(f => f.FilmActors).ThenInclude(f => f.Actor).ThenInclude(a => a.Photos)
                .Include(f => f.FilmGenres).ThenInclude(g => g.Genre)
                .SingleOrDefaultAsync(x => x.Id == filmId);

            if (film == null)
            {
                return new FilmDto();
            }

            return film.GenFilmInfo_Map();
        }

        public async Task<IEnumerable<SearchResult>> GetSearchResultsAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return [];
            }

            var filmResults = await (from films in _dbContext.Films
                                     from poster in _dbContext.Screenshots
                                        .Where(s => s.FilmId == films.Id && s.IsPoster)
                                        .DefaultIfEmpty()
                                     where films.Name != null && films.Name.StartsWith(query, StringComparison.CurrentCultureIgnoreCase)
                                        || _dbContext.FilmGenres
                                            .Where(fg => fg.FilmId == films.Id)
                                            .Select(fg => fg.Genre.Name)
                                            .Any(g => g != null && g.StartsWith(query, StringComparison.CurrentCultureIgnoreCase))
                                        || _dbContext.FilmActors
                                            .Where(fa => fa.FilmId == films.Id)
                                            .Select(fa => fa.Actor)
                                            .Any(a => a.FirstName != null && a.FirstName.StartsWith(query, StringComparison.CurrentCultureIgnoreCase)
                                                || a.LastName != null && a.LastName.StartsWith(query, StringComparison.CurrentCultureIgnoreCase)
                                                || $"{a.FirstName} {a.LastName}".StartsWith(query, StringComparison.CurrentCultureIgnoreCase))
                                     select new
                                     {
                                         FilmId = films.Id,
                                         FilmName = films.Name,
                                         FilmDescription = films.Description,
                                         films.Year,
                                         films.Rating,
                                         PosterUrl = poster.ImageUrl
                                     }).ToListAsync();

            var searchResults = filmResults
                .GroupBy(fr => new { fr.FilmId, fr.FilmName, fr.FilmDescription, fr.Year, fr.Rating, fr.PosterUrl })
                .Select(g => new SearchResult
                {
                    Id = g.Key.FilmId,
                    Name = g.Key.FilmName,
                    Description = g.Key.FilmDescription,
                    Year = g.Key.Year,
                    Rating = g.Key.Rating.GetValueOrDefault(),
                    PosterUrl = g.Key.PosterUrl
                })
                .ToList();

            return searchResults;
        }
    }
}