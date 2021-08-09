namespace FavoriteMovies.Domain.Models
{
    public class MovieAndGenre : DomainObject
    {
        public int MovieId { get; set; }
        public MovieDetail Movie { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}