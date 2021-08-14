using System.Collections.ObjectModel;
using System.Windows.Input;
using FavoriteMovies.Domain.Models;
using FavoriteMovies.Domain.Services;

namespace FavoriteMovies.Wpf.ViewModels
{
    public class MovieDiscoverViewModel:ObservableObject
    {
        private readonly IMovieDiscoverService _movieDiscoverService;

        public MovieDiscoverViewModel(IMovieDiscoverService movieDiscoverService)
        {
            _movieDiscoverService = movieDiscoverService;
        }

        public ObservableCollection<Movie> Movies { get; set; }

        public ICommand SearchMovieCommand { get; set; }
    }
}