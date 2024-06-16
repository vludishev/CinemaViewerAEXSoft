namespace CV.Infrastructure.Entities
{
    public class Genre : FilmItem
    {
        public Genre()
        {
            FilmGenres = [];
        }

        public IList<FilmGenre> FilmGenres { get; private set; } = [];
    }
}
