using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavoriteMovies.Domain.Models;
using FavoriteMovies.Domain.Services;
using FavoriteMovies.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace FavoriteMovies.Wpf.Data
{
    public class FavoriteMovieDataService:IFavoriteMovieDataService
    {
        private ApplicationContext _context;

        public FavoriteMovieDataService(Task<ApplicationContext> context)
        {
            LoadContextAsync(context);
        }

        public async Task AddAsync(MovieDetail movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(MovieDetail movie)
        {
            var deletable = _context.Movies.SingleOrDefault(m => m.ImdbId == movie.ImdbId);

            if (deletable == null)
                return; 
            
            _context.MovieAndActors.RemoveRange(_context.MovieAndActors.Where(ma => ma.MovieId == deletable.Id));
            _context.MovieAndDirectors.RemoveRange(_context.MovieAndDirectors.Where(md => md.MovieId == deletable.Id));
            _context.MovieAndGenres.RemoveRange(_context.MovieAndGenres.Where(mg => mg.MovieId == deletable.Id));
            _context.MovieAndLanguages.RemoveRange(_context.MovieAndLanguages.Where(ml => ml.MovieId == deletable.Id));
            _context.MovieAndWriters.RemoveRange(_context.MovieAndWriters.Where(mw => mw.MovieId == deletable.Id));

            _context.Movies.Remove(deletable);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExistAsync(MovieDetail movie)
        {
            return await _context.Movies.AnyAsync(m => m.ImdbId == movie.ImdbId);
        }

        public async Task<List<MovieDetail>> GetAllAsync()
        {
            return await Task.Factory.StartNew(() => _context.Movies.ToList());
        }

        private async void LoadContextAsync(Task<ApplicationContext> context)
        {
            _context = await context;
        }
    }
}