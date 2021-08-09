namespace FavoriteMovies.Domain.Models
{
    public class MovieAndActor:DomainObject
    {
        public int MovieId { get; set; }
        public MovieDetail Movie { get; set; }
        public int ActorId { get; set; }
        public Person Actor { get; set; }
    }
}