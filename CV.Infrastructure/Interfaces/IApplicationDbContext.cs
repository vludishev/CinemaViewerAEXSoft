using CV.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CV.Infrastructure.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Film> Films { get; }

        DbSet<Actor> Actors { get; }

        DbSet<Genre> Genres { get; }

        DbSet<Screenshot> Screenshots { get; }

        DbSet<Photo> Photos { get; }

        DbSet<FilmGenre> FilmGenres { get; }

        DbSet<FilmActor> FilmActors { get; }
    }
}
