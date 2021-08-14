using System.Collections.Generic;
using System.Threading.Tasks;
using FavoriteMovies.Domain.Services.Results;

namespace FavoriteMovies.Domain.Services
{
    public interface IMovieDiscoverService
    {
        Task<List<MovieResult>> GetMoviesAsync(string name);
    }
}