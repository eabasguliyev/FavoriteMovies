using System.Collections.Generic;
using System.Linq;
using FavoriteMovies.Domain.Models;

namespace FavoriteMovies.Wpf.Wrappers
{
    public class MovieDetailWrapper:ModelWrapper<MovieDetail>
    {
        public MovieDetailWrapper(MovieDetail model) : base(model)
        {
        }

        public string Title => Model.Title;

        public string PosterLink => Model.PosterLink;

        public short Year => Model.Year;

        public string Language => Model.Language.Name;

        public string Director => Model.Director.Name;
        public string Country => Model.Country.Name;

        public List<Person> Writers => Model.Writers.Select(w => w.Writer).ToList();
        public List<Person> Actors => Model.Actors.Select(a => a.Actor).ToList();
        public List<Genre> Genres => Model.Genres.Select(g => g.Genre).ToList();
        public string Plot => Model.Plot;
    }
}