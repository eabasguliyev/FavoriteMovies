namespace FavoriteMovies.Domain.Models
{
    public class MovieAndWriter:DomainObject
    {
        public int MovieId { get; set; }
        public virtual MovieDetail Movie { get; set; }
        public int WriterId { get; set; }
        public virtual Person Writer { get; set; }
    }
}