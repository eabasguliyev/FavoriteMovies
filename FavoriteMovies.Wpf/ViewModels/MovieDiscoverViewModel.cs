using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using FavoriteMovies.Domain.Models;
using FavoriteMovies.Domain.Services;
using FavoriteMovies.Domain.Services.Api;
using FavoriteMovies.Domain.Services.Api.Results;
using FavoriteMovies.OmdbApi.Services;
using FavoriteMovies.Wpf.Events;
using FavoriteMovies.Wpf.Wrappers;
using Prism.Commands;
using Prism.Events;

namespace FavoriteMovies.Wpf.ViewModels
{
    public class MovieDiscoverViewModel:ObservableObject, IMovieDiscoverViewModel
    {
        private readonly IMovieDiscoverService _movieDiscoverService;
        private readonly IEventAggregator _eventAggregator;
        private readonly ApiResultConverter _apiResultConverter;
        private string _text;
        private MovieWrapper _selectedMovie;

        public MovieDiscoverViewModel(IMovieDiscoverService movieDiscoverService, IEventAggregator eventAggregator, ApiResultConverter apiResultConverter)
        {
            _movieDiscoverService = movieDiscoverService;
            _eventAggregator = eventAggregator;
            _apiResultConverter = apiResultConverter;

            Movies = new ObservableCollection<MovieWrapper>();

            SearchMovieCommand = new DelegateCommand(OnSearchMovieExecuteAsync);
            OpenMovieDetailViewCommand = new DelegateCommand(OnOpenMovieDetailViewExecute, OnOpenMovieDetailViewCanExecute);
        }

        public ObservableCollection<MovieWrapper> Movies { get; }

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        public MovieWrapper SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchMovieCommand { get; }
        public ICommand OpenMovieDetailViewCommand { get; }

        private async void OnSearchMovieExecuteAsync()
        {
            List<MovieResult> movieResults = await SearchMoviesAsync(Text);

            LoadMovies(movieResults);
        }

        private void LoadMovies(List<MovieResult> movieResults)
        {
            Movies.Clear();

            foreach (var movie in _apiResultConverter.ConvertMovies(movieResults))
            {
                Movies.Add(new MovieWrapper(movie));
            }
        }

        private async Task<List<MovieResult>> SearchMoviesAsync(string movieName)
        {
            return await _movieDiscoverService.GetMoviesAsync(movieName);
        }

        private void OnOpenMovieDetailViewExecute()
        {
            _eventAggregator.GetEvent<OpenMovieDetailViewEvent>().Publish(SelectedMovie.ImdbId);
        }

        private bool OnOpenMovieDetailViewCanExecute()
        {
            return SelectedMovie != null;
        }
    }
}