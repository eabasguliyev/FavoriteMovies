using System.Collections.Generic;
using System.Threading.Tasks;
using FavoriteMovies.Domain.Services.Results;

namespace FavoriteMovies.Domain.Services
{
    public interface IMovieService
    {
        Task<List<MovieResult>> GetMoviesAsync(string name);
    }
}