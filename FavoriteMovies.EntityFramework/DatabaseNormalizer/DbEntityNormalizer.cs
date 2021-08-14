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
            foreach (var movieAndDirector in movieDetail.Directors)
            {
                var director = _context.People.FirstOrDefault(p => p.Name == movieAndDirector.Director.Name);

                if (director != null)
                {
                    movieAndDirector.DirectorId = director.Id;
                    movieAndDirector.Director = null;
                }
            }

            //var country = _context.Countries.SingleOrDefault(c => c.Name == movieDetail.Country.Name);

            //if (country != null)
            //    movieDetail.Country = country;

            foreach (var movieAndCountry in movieDetail.Countries)
            {
                var country = _context.Countries.FirstOrDefault(c => c.Name == movieAndCountry.Country.Name);

                if (country != null)
                {
                    movieAndCountry.CountryId = country.Id;
                    movieAndCountry.Country = null;
                }
            }

            foreach (var movieAndLanguage in movieDetail.Languages)
            {
                var language = _context.Languages.FirstOrDefault(l => l.Name == movieAndLanguage.Language.Name);

                if (language != null)
                {
                    movieAndLanguage.LanguageId = language.Id;
                    movieAndLanguage.Language = null;
                }
            }

            foreach (var movieAndWriter in movieDetail.Writers)
            {
                var writer = _context.People.FirstOrDefault(p => p.Name == movieAndWriter.Writer.Name);

                if (writer != null)
                {
                    movieAndWriter.WriterId = writer.Id;
                    movieAndWriter.Writer = null;
                }
            }


            foreach (var movieAndActor in movieDetail.Actors)
            {
                var actor = _context.People.FirstOrDefault(p => p.Name == movieAndActor.Actor.Name);

                if (actor != null)
                {
                    movieAndActor.ActorId = actor.Id;
                    movieAndActor.Actor = null;
                }
            }

            foreach (var movieAndGenre in movieDetail.Genres)
            {
                var genre = _context.Genres.FirstOrDefault(g => g.Name == movieAndGenre.Genre.Name);

                if (genre != null)
                {
                    movieAndGenre.GenreId = genre.Id;
                    movieAndGenre.Genre = null;
                }
            }
        }
    }
}