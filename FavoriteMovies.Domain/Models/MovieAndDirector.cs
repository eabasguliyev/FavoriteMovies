namespace FavoriteMovies.Domain.Models
{
    public class MovieAndDirector : DomainObject
    {
        public int MovieId { get; set; }
        public virtual MovieDetail Movie { get; set; }
        public int DirectorId { get; set; }
        public virtual Director Director { get; set; }
    }
}