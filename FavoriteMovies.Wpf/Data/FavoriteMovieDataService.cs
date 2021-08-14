using System.Threading.Tasks;
using FavoriteMovies.Domain.Models;
using FavoriteMovies.Domain.Services;
using FavoriteMovies.EntityFramework;

namespace FavoriteMovies.Wpf.Data
{
    public class FavoriteMovieDataService:IFavoriteMovieDataService
    {
        private readonly ApplicationContext _context;

        public FavoriteMovieDataService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task AddAsync(MovieDetail movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(MovieDetail movie)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}