namespace CV.Infrastructure.Entities
{
    public class Film : FilmItem
    {
        public Film()
        {
            Screenshots = [];
            FilmActors = [];
            FilmGenres = [];
        }

        public string? Description { get; set; }

        public double? Rating { get; set; }

        public string? Year { get; set; }

        public IList<Screenshot> Screenshots { get; private set; } = null!;
        public IList<FilmGenre> FilmGenres { get; private set; } = null!;
        public IList<FilmActor> FilmActors { get; private set; } = null!;
    }

    public class Screenshot : Image
    {
        public int FilmId { get; set; }
        public Film Film { get; set; } = null!;
        public bool IsPoster { get; set; }
    }

    public class FilmGenre
    {
        public int FilmId { get; set; }
        public Film Film { get; set; } = null!;
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;
    }

    public class FilmActor
    {
        public int FilmId { get; set; }
        public Film Film { get; set; } = null!;
        public int ActorId { get; set; }
        public Actor Actor { get; set; } = null!;
    }
}
