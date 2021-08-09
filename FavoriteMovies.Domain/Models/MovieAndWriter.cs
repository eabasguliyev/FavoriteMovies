namespace FavoriteMovies.Domain.Models
{
    public class MovieAndWriter:DomainObject
    {
        public int MovieId { get; set; }
        public MovieDetail Movie { get; set; }
        public int WriterId { get; set; }
        public Person Writer { get; set; }
    }
}