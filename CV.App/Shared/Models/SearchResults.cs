namespace CV.App.Shared.Models
{
    public class SearchResult
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PosterUrl { get; set; }
        public string? Description { get; set; }
        public double? Rating { get; set; }
        public string? Year { get; set; }
    }
}
