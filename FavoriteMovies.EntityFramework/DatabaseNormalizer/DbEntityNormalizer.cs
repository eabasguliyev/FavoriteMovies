using System.Linq;
using System.Threading.Tasks;
using FavoriteMovies.Domain.Models;

namespace FavoriteMovies.EntityFramework.DatabaseNormalizer
{
    public class DbEntityNormalizer
    {
        private ApplicationContext _context;

        public DbEntityNormalizer(Task<ApplicationContext> context)
        {
            LoadContextAsync(context);
        }

        private async void LoadContextAsync(Task<ApplicationContext> context)
        {
            _context = await context;
        }

        public void MovieEntityNormalizer(MovieDetail movieDetail)
        {
            foreach (var movieAndDirector in movieDetail.Directors)
            {
                Director director = null;
                if (movieAndDirector.Director == null)
                {
                    director = _context.Directors.FirstOrDefault(d => d.Id == movieAndDirector.DirectorId);
                }
                else
                {
                    director = _context.Directors.FirstOrDefault(d => d.Name == movieAndDirector.Director.Name);
                }


                if (director != null)
                {
                    movieAndDirector.DirectorId = director.Id;
                    movieAndDirector.Director = null;
                }

                movieAndDirector.Id = 0;
                movieAndDirector.MovieId = 0;

            }
            

            foreach (var movieAndCountry in movieDetail.Countries)
            {
                Country country = null;

                if (movieAndCountry.Country == null)
                {
                    country = _context.Countries.FirstOrDefault(c => c.Id == movieAndCountry.CountryId);
                }
                else
                {
                    country = _context.Countries.FirstOrDefault(c => c.Name == movieAndCountry.Country.Name);
                }

                if (country != null)
                {
                    movieAndCountry.CountryId = country.Id;
                    movieAndCountry.Country = null;
                }

                movieAndCountry.Id = 0;
                movieAndCountry.MovieId = 0;
            }

            foreach (var movieAndLanguage in movieDetail.Languages)
            {
                Language language = null;

                if (movieAndLanguage.Language == null)
                {
                    language = _context.Languages.FirstOrDefault(l => l.Id == movieAndLanguage.LanguageId);
                }
                else
                {
                    language = _context.Languages.FirstOrDefault(l => l.Name == movieAndLanguage.Language.Name);
                }

                if (language != null)
                {
                    movieAndLanguage.LanguageId = language.Id;
                    movieAndLanguage.Language = null;
                }

                movieAndLanguage.Id = 0;
                movieAndLanguage.MovieId = 0;
            }

            foreach (var movieAndWriter in movieDetail.Writers)
            {
                Writer writer = null;

                if (movieAndWriter.Writer == null)
                {
                    writer = _context.Writers.FirstOrDefault(w => w.Id == movieAndWriter.WriterId);
                }
                else
                {
                    writer = _context.Writers.FirstOrDefault(w => w.Name == movieAndWriter.Writer.Name);
                }


                if (writer != null)
                {
                    movieAndWriter.WriterId = writer.Id;
                    movieAndWriter.Writer = null;
                }

                movieAndWriter.Id = 0;
                movieAndWriter.MovieId = 0;
            }


            foreach (var movieAndActor in movieDetail.Actors)
            {
                Actor actor = null;

                if (movieAndActor.Actor == null)
                {
                    actor = _context.Actors.FirstOrDefault(a => a.Id == movieAndActor.ActorId);
                }
                else
                { 
                    actor = _context.Actors.FirstOrDefault(p => p.Name == movieAndActor.Actor.Name);
                }

                if (actor != null)
                {
                    movieAndActor.ActorId = actor.Id;
                    movieAndActor.Actor = null;
                }

                movieAndActor.Id = 0;
                movieAndActor.MovieId = 0;
            }

            foreach (var movieAndGenre in movieDetail.Genres)
            {
                Genre genre = null;

                if (movieAndGenre.Genre == null)
                {
                    genre = _context.Genres.FirstOrDefault(g => g.Id == movieAndGenre.GenreId);
                }
                else
                {
                    genre = _context.Genres.FirstOrDefault(g => g.Name == movieAndGenre.Genre.Name);
                }

                if (genre != null)
                {
                    movieAndGenre.GenreId = genre.Id;
                    movieAndGenre.Genre = null;
                }

                movieAndGenre.Id = 0;
                movieAndGenre.MovieId = 0;
            }
        }
    }
}