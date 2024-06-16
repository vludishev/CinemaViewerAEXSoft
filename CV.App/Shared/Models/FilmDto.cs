namespace CV.App.Shared.Models
{
    public class FilmDto : FilmItemDto
    {
        public FilmDto()
        {
            Screenshots = [];
            FilmActors = [];
            FilmGenres = [];
        }

        public string? Description { get; set; }

        public double? Rating { get; set; }

        public string? Year { get; set; }

        public IList<ScreenshotDto> Screenshots { get; set; }
        public IList<FilmActorDto> FilmActors { get; set; }
        public IList<FilmGenreDto> FilmGenres { get; set; }
    }

    public class FilmActorDto
    {
        public int FilmId { get; set; }
        public FilmDto Film { get; set; } = null!;
        public int ActorId { get; set; }
        public ActorDto Actor { get; set; } = null!;
    }

    public class FilmGenreDto
    {
        public int FilmId { get; set; }
        public FilmDto Film { get; set; } = null!;
        public int GenreId { get; set; }
        public GenreDto Genre { get; set; } = null!;
    }

    public class ScreenshotDto
    {
        public bool IsPoster { get; set; }

        public string ImageUrl { get; set; } = null!;
    }
}
