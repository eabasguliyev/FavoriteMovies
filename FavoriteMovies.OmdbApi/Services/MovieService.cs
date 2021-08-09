using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FavoriteMovies.Domain.Services;
using FavoriteMovies.Domain.Services.Results;
using Microsoft.Extensions.Configuration;

namespace FavoriteMovies.OmdbApi.Services
{
    public class MovieService:IMovieService
    {
        private readonly string _apiKey;

        public MovieService()
        {
            _apiKey = GetApiKey();
        }
        public async Task<MovieDetailResult> GetMovieAsync(string imdbId)
        {
            using var client = new OmdbApiHttpClient();

            var uri = $"?i={imdbId}&apikey={_apiKey}";

            return await client.GetAsync<MovieDetailResult>(uri);
        }

        public async Task<List<MovieResult>> GetMoviesAsync(string name)
        {
            using var client = new OmdbApiHttpClient();

            var uri = $"?s={name}&plot=full&apikey={_apiKey}";

            return await client.GetAsync<List<MovieResult>>(uri, "Search");
        }

        protected string GetApiKey()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json", false)
                .Build();

            return configuration.GetSection("OmdbApiKey").Value;
        }
    }
}