using System.Threading.Tasks;
using FavoriteMovies.Domain.Services.Results;

namespace FavoriteMovies.Domain.Services
{
    public interface IMovieDiscoverService
    {
        Task<MovieDetailResult> GetMovieAsync(string imdbId);
    }
}