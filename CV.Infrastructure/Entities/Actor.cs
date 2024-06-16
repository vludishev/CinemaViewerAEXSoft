namespace CV.Infrastructure.Entities
{
    public class Actor : FilmItem
    {
        public Actor()
        {
            Photos = [];
            FilmActors = [];
        }

        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public DateTime? Birthdate { get; set; }

        public string? Bio { get; set; }

        public IList<Photo> Photos { get; private set; } = [];
        public IList<FilmActor> FilmActors { get; private set; } = [];
    }

    public class Photo : Image
    {
        public int ActorId { get; set; }
        public Actor Actor { get; set; } = null!;
    }
}
