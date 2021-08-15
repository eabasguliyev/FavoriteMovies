using System.Collections.Generic;
using System.Linq;
using FavoriteMovies.Domain.Models;

namespace FavoriteMovies.Wpf.Wrappers
{
    public class MovieDetailWrapper:MovieWrapper
    {
        public new MovieDetail Model => base.Model as MovieDetail;

        public MovieDetailWrapper(MovieDetail model) : base(model)
        {
        }

        public short Year => Model.Year;

        public List<Language> Languages => Model.Languages.Select(l => l.Language).ToList();

        public List<Director> Directors => Model.Directors.Select(d => d.Director).ToList();

        public List<Country> Countries => Model.Countries.Select(c => c.Country).ToList();
        public List<Writer> Writers => Model.Writers.Select(w => w.Writer).ToList();
        public List<Actor> Actors => Model.Actors.Select(a => a.Actor).ToList();
        public List<Genre> Genres => Model.Genres.Select(g => g.Genre).ToList();
        public string Plot => Model.Plot;
    }
}