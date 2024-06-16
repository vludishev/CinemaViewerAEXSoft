namespace CV.App.Shared.Models
{
    public class ActorDto : FilmItemDto
    {
        public ActorDto()
        {
            Photos = [];
        }

        public IList<PhotoDto> Photos { get; set; }
    }

    public class PhotoDto
    {
        public string ImageUrl { get; set; } = null!;
    }
}
