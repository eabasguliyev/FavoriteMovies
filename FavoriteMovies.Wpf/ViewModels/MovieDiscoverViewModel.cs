using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using FavoriteMovies.Domain.Models;
using FavoriteMovies.Domain.Services;
using FavoriteMovies.Domain.Services.Results;
using FavoriteMovies.OmdbApi.Services;
using FavoriteMovies.Wpf.Wrappers;
using Prism.Commands;

namespace FavoriteMovies.Wpf.ViewModels
{
    public class MovieDiscoverViewModel:ObservableObject, IMovieDiscoverViewModel
    {
        private readonly IMovieDiscoverService _movieDiscoverService;
        private string _text;

        public MovieDiscoverViewModel(IMovieDiscoverService movieDiscoverService)
        {
            _movieDiscoverService = movieDiscoverService;

            Movies = new ObservableCollection<MovieWrapper>();

            SearchMovieCommand = new DelegateCommand(OnSearchMovieExecuteAsync);
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

        public ICommand SearchMovieCommand { get; }

        private async void OnSearchMovieExecuteAsync()
        {
            List<MovieResult> movieResults = await SearchMoviesAsync(Text);

            LoadMovies(movieResults);
        }

        private void LoadMovies(List<MovieResult> movieResults)
        {
            var resultConverter = new ApiResultConverter();

            Movies.Clear();

            foreach (var movie in resultConverter.ConvertMovies(movieResults))
            {
                Movies.Add(new MovieWrapper(movie));
            }
        }

        private async Task<List<MovieResult>> SearchMoviesAsync(string movieName)
        {
            return await _movieDiscoverService.GetMoviesAsync(movieName);
        }
    }
}