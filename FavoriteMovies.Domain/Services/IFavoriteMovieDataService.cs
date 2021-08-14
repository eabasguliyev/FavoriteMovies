using System.Threading.Tasks;
using FavoriteMovies.Domain.Models;

namespace FavoriteMovies.Domain.Services
{
    public interface IFavoriteMovieDataService
    {
        Task AddAsync(MovieDetail movie);
        Task RemoveAsync(MovieDetail movie);
    }
}