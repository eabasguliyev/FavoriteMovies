using System;
using System.Collections.Generic;
using System.Linq;
using FavoriteMovies.Domain.Models;
using FavoriteMovies.Domain.Services.Api.Results;

namespace FavoriteMovies.OmdbApi.Services
{
    public class ApiResultConverter
    {
        public IEnumerable<Movie> ConvertMovies(List<MovieResult> movieResults)
        {
            foreach (var movieResult in movieResults)
            {
                yield return ConvertMovie(movieResult);
            }
        }

        public Movie ConvertMovie(MovieResult movieResult)
        {
            short.TryParse(movieResult.Year, out var movieYear);
            var type = movieResult.Type[0].ToString().ToUpper() + movieResult.Type.ToLower().Substring(1);

            Enum.TryParse(typeof(MovieType), type , out object movieType);

            var movie = new MovieDetail()
            {
                ImdbId = movieResult.imdbID,
                Title = movieResult.Title,
                Year = movieYear,
                PosterLink = movieResult.Poster,
                Type = (MovieType?) movieType ?? MovieType.Movie
            };


            return movie;
        }

        public List<MovieDetail> ConvertMovieDetails(List<MovieDetailResult> movieDetailResults)
        {
            var movieDetails = new List<MovieDetail>();

            movieDetailResults.ForEach(mdr => movieDetails.Add(ConvertMovieDetail(mdr)));

            return movieDetails;
        }
        public MovieDetail ConvertMovieDetail(MovieDetailResult movieDetailResult)
        {
            var movieDetail = ConvertMovie(movieDetailResult) as MovieDetail;

            var actors = ParseData<Actor>(movieDetailResult.Actors);

            foreach (var actor in actors)
            {
                movieDetail.Actors.Add(new MovieAndActor()
                {
                    Movie = movieDetail,
                    Actor = actor
                });
            }

            var writers = ParseData<Writer>(movieDetailResult.Writer);

            foreach (var writer in writers)
            {
                movieDetail.Writers.Add(new MovieAndWriter()
                {
                    Movie = movieDetail,
                    Writer = writer
                });
            }

            //movieDetail.Director = new Person()
            //{
            //    Name = movieDetailResult.Director.Trim()
            //};

            //movieDetail.Country = new Country()
            //{
            //    Name = movieDetailResult.Country.Trim()
            //};

            //movieDetail.Language = new Language()
            //{
            //    Name = movieDetailResult.Language.Trim()
            //};

            var countries = ParseData<Country>(movieDetailResult.Country);

            foreach (var country in countries)
            {
                movieDetail.Countries.Add(new MovieAndCountry()
                {
                    Movie = movieDetail,
                    Country = country
                });
            }

            var directors = ParseData<Director>(movieDetailResult.Director);

            foreach (var director in directors)
            {
                movieDetail.Directors.Add(new MovieAndDirector()
                {
                    Movie = movieDetail,
                    Director = director
                });
            }

            var languages = ParseData<Language>(movieDetailResult.Language);

            foreach (var language in languages)
            {
                movieDetail.Languages.Add(new MovieAndLanguage()
                {
                    Movie = movieDetail,
                    Language = language
                });
            }

            var genres = ParseData<Genre>(movieDetailResult.Genre);

            foreach (var genre in genres)
            {
                movieDetail.Genres.Add(new MovieAndGenre()
                {
                    Movie = movieDetail,
                    Genre = genre
                });
            }

            movieDetail.Plot = movieDetailResult.Plot;

            return movieDetail;
        }

        private List<T> ParseData<T>(string data) where T:new()
        {
            return data.Split(',').Select(p =>
            {
                var obj = new T();

                typeof(T).GetProperty("Name")?.SetValue(obj, p.Trim());
                return obj;
            }).ToList();
        }
    }
}