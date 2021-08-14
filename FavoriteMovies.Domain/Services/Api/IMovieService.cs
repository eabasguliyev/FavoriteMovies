using System.Threading.Tasks;
using FavoriteMovies.Domain.Services.Api.Results;

namespace FavoriteMovies.Domain.Services.Api
{
    public interface IMovieService
    {
        Task<MovieDetailResult> GetMovieAsync(string imdbId);
    }
}