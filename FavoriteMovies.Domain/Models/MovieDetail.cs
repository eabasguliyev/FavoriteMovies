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
        public Person Director { get; set; }
        public List<MovieAndWriter> Writers { get; set; }
        public List<MovieAndActor> Actors { get; set; }
        public string Plot { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public List<MovieAndGenre> Genres { get; set; }

    }
}