namespace FavoriteMovies.Domain.Models
{
    public class MovieAndGenre : DomainObject
    {
        public int MovieId { get; set; }
        public virtual MovieDetail Movie { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}