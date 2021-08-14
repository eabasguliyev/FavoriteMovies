using System.Collections.Generic;
using System.Threading.Tasks;
using FavoriteMovies.Domain.Services.Api.Results;

namespace FavoriteMovies.Domain.Services.Api
{
    public interface IMovieDiscoverService
    {
        Task<List<MovieResult>> GetMoviesAsync(string name);
    }
}