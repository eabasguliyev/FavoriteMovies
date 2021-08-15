using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FavoriteMovies.Domain.Services;
using FavoriteMovies.Wpf.Events;
using FavoriteMovies.Wpf.Wrappers;
using Prism.Commands;
using Prism.Events;

namespace FavoriteMovies.Wpf.ViewModels
{
    public class FavoriteListViewModel:ObservableObject
    {
        private readonly IFavoriteMovieDataService _favoriteMovieDataService;
        private readonly IEventAggregator _eventAggregator;
        private MovieDetailWrapper _selectedMovie;

        public FavoriteListViewModel(IFavoriteMovieDataService favoriteMovieDataService, IEventAggregator eventAggregator)
        {
            _favoriteMovieDataService = favoriteMovieDataService;
            _eventAggregator = eventAggregator;

            Movies = new ObservableCollection<MovieDetailWrapper>();

            LoadCommand = new DelegateCommand(OnLoadExecuteAsync);
            OpenMovieDetailViewCommand = new DelegateCommand(OnOpenMovieDetailViewExecute);
        }

        public ICommand LoadCommand { get; }
        public ICommand OpenMovieDetailViewCommand { get; }

        public MovieDetailWrapper SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<MovieDetailWrapper> Movies { get; }

        private async void OnLoadExecuteAsync()
        {
            var movies = await _favoriteMovieDataService.GetAllAsync();

            Movies.Clear();

            foreach (var movie in movies)
            {
                Movies.Add(new MovieDetailWrapper(movie));
            }
        }

        private void OnOpenMovieDetailViewExecute()
        {
            _eventAggregator.GetEvent<OpenMovieDetailViewEvent>().Publish(SelectedMovie.ImdbId);
        }
    }
}