using System.Linq;
using FavoriteMovies.Domain.Models;

namespace FavoriteMovies.EntityFramework.DatabaseNormalizer
{
    public class DbEntityNormalizer
    {
        private readonly ApplicationContext _context;

        public DbEntityNormalizer(ApplicationContext context)
        {
            _context = context;
        }
        public void MovieEntityNormalizer(MovieDetail movieDetail)
        {
            var director = _context.People.FirstOrDefault(p => p.Name == movieDetail.Director.Name);

            if (director != null)
                movieDetail.Director = director;

            var country = _context.Countries.SingleOrDefault(c => c.Name == movieDetail.Country.Name);

            if (country != null)
                movieDetail.Country = country;

            var language = _context.Languages.SingleOrDefault(l => l.Name == movieDetail.Language.Name);

            if (language != null)
                movieDetail.Language = language;

            foreach (var movieAndWriter in movieDetail.Writers)
            {
                var writer = _context.People.FirstOrDefault(p => p.Name == movieAndWriter.Writer.Name);

                if (writer != null)
                    movieAndWriter.Writer = writer;
            }


            foreach (var movieAndActor in movieDetail.Actors)
            {
                var actor = _context.People.FirstOrDefault(p => p.Name == movieAndActor.Actor.Name);

                if (actor != null)
                    movieAndActor.Actor = actor;
            }

            foreach (var movieAndGenre in movieDetail.Genres)
            {
                var genre = _context.Genres.FirstOrDefault(g => g.Name == movieAndGenre.Genre.Name);

                if (genre != null)
                    movieAndGenre.Genre = genre;
            }
        }
    }
}