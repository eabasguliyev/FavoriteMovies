using System.Collections.Generic;
using System.Threading.Tasks;
using FavoriteMovies.Domain.Services;
using FavoriteMovies.Domain.Services.Results;

namespace FavoriteMovies.OmdbApi.Services
{
    public class MovieDataService:IMovieDataService
    {
        public async Task<MovieDetailResult> GetMovieAsync(string imdbId)
        {
            using var client = new OmdbApiHttpClient();

            var uri = $"?i={imdbId}&apikey=b299d290";

            return await client.GetAsync<MovieDetailResult>(uri);
        }

        public async Task<List<MovieResult>> GetMoviesAsync(string name)
        {
            using var client = new OmdbApiHttpClient();

            var uri = $"?s={name}&plot=full&apikey=b299d290";

            return await client.GetAsync<List<MovieResult>>(uri, "Search");
        }
    }
}