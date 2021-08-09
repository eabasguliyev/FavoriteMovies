using System.Collections.Generic;

namespace FavoriteMovies.Domain.Models
{
    public class MovieDetail:Movie
    {
        public MovieDetail()
        {
            Writers = new List<MovieAndWriter>();
            Actors = new List<MovieAndActor>();
            Genres = new List<MovieAndGenre>();
        }

        public int DirectorId { get; set; }
        public virtual Person Director { get; set; }
        public virtual List<MovieAndWriter> Writers { get; set; }
        public virtual List<MovieAndActor> Actors { get; set; }
        public string Plot { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
        public virtual List<MovieAndGenre> Genres { get; set; }

    }
}