using CV.App.Shared.Models;
using CV.Infrastructure.Entities;

namespace CV.App.Mapper
{
    public static class FilmMappingExt
    {
        private static TDestination Map<TSource, TDestination>(TSource sourceObject)
        {
            var destinationObject = Activator.CreateInstance<TDestination>();
            if (sourceObject != null)
            {
                foreach (var sourceProperty in typeof(TSource).GetProperties())
                {
                    var destinationProperty = typeof(TDestination).GetProperty(sourceProperty.Name);
                    destinationProperty?.SetValue(destinationObject, sourceProperty.GetValue(sourceObject));
                }
            }
            return destinationObject;
        }

        public static FilmDto GenFilmInfo_Map(this Film film)
        {

            var poster = string.Empty;
            var screenshotsDto = new List<ScreenshotDto>();
            foreach (var sc in film.Screenshots)
            {
                if (sc.IsPoster)
                {
                    poster = sc.ImageUrl;
                    continue;
                }

                screenshotsDto.Add(
                    new ScreenshotDto()
                    {
                        ImageUrl = sc.ImageUrl,
                        IsPoster = sc.IsPoster,
                    });
            }

            return new FilmDto()
            {
                Name = film.Name,
                Description = film.Description,
                Rating = film.Rating,
                Year = film.Year,
                ImageUrl = film.Screenshots.FirstOrDefault(s => s.IsPoster)!.ImageUrl,

                Screenshots = screenshotsDto,
                FilmGenres = film.FilmGenres.Select(g => new FilmGenreDto()
                {
                    Genre = new GenreDto()
                    {
                        Name = g.Genre.Name,
                        ImageUrl = g.Genre.ImageUrl
                    }
                }).ToArray(),

                FilmActors = film.FilmActors.Select(a => new FilmActorDto()
                {
                    Actor = new ActorDto()
                    {
                        Name = $"{a.Actor.FirstName} {a.Actor.LastName}",
                        // Нужна картинка заглушки, если фото не имеется
                        ImageUrl = a.Actor.Photos.FirstOrDefault()?.ImageUrl ?? string.Empty
                    }
                }).ToArray()
            };
        }
    }
}
