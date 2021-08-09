namespace FavoriteMovies.Domain.Models
{
    public class Movie:DomainObject
    {
        public string ImdbId { get; set; }
        public MovieType Type { get; set; }
        public string Title { get; set; }
        public short Year { get; set; }
        public string PosterLink { get; set; }
    }

    public enum MovieType
    {
        Movie,
        Series
    }
}
