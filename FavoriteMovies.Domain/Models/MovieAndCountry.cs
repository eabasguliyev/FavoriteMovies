namespace FavoriteMovies.Domain.Models
{
    public class MovieAndCountry : DomainObject
    {
        public int MovieId { get; set; }
        public virtual MovieDetail Movie { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}