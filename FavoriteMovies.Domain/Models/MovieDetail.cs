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
            Directors = new List<MovieAndDirector>();
            Countries = new List<MovieAndCountry>();
            Languages = new List<MovieAndLanguage>();
        }

        public virtual List<MovieAndDirector> Directors { get; set; }
        public virtual List<MovieAndWriter> Writers { get; set; }
        public virtual List<MovieAndActor> Actors { get; set; }
        public string Plot { get; set; }
        public virtual List<MovieAndCountry> Countries { get; set; }

        public virtual List<MovieAndLanguage> Languages { get; set; }
        public virtual List<MovieAndGenre> Genres { get; set; }

    }
}