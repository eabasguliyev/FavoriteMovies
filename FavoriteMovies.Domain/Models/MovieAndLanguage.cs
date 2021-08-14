namespace FavoriteMovies.Domain.Models
{
    public class MovieAndLanguage : DomainObject
    {
        public int MovieId { get; set; }
        public virtual MovieDetail Movie { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}