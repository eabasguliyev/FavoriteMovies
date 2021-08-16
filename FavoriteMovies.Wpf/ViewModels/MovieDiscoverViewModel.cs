using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using FavoriteMovies.Domain.Models;
using FavoriteMovies.Domain.Services;
using FavoriteMovies.Domain.Services.Api;
using FavoriteMovies.Domain.Services.Api.Results;
using FavoriteMovies.Domain.Services.File;
using FavoriteMovies.OmdbApi.Services;
using FavoriteMovies.Wpf.Events;
using FavoriteMovies.Wpf.Wrappers;
using Prism.Commands;
using Prism.Events;

namespace FavoriteMovies.Wpf.ViewModels
{
    public class MovieDiscoverViewModel:ObservableObject, IMovieDiscoverViewModel
    {
        private readonly IFileDataService<MovieResult> _movieFileDataService;
        private readonly IMovieDiscoverService _movieDiscoverService;
        private readonly IEventAggregator _eventAggregator;
        private readonly ApiResultConverter _apiResultConverter;
        private string _text;
        private MovieWrapper _selectedMovie;
        private string _fileName = "searchResults.json";

        public MovieDiscoverViewModel(IMovieDiscoverService movieDiscoverService, IFileDataService<MovieResult> movieFileDataService, IEventAggregator eventAggregator, ApiResultConverter apiResultConverter)
        {
            _movieFileDataService = movieFileDataService;
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
            Task<List<MovieResult>> apiResults = SearchMoviesAsync(Text);

            var isAppend = false;

            List<MovieResult> moviesFromFile = null;

            var movies = SearchFromFile(ref moviesFromFile, ref isAppend);

            if (movies != null && movies.Count != 0)
            {
                LoadMovies(movies);
                isAppend = true;
            }

            var movieResults = await apiResults;

            // filter search results
            if (movieResults == null)
            {
                if (movies?.Any() == false)
                {
                    Movies.Clear();
                }
                return;
            }

            var filteredMovies = FilterMovieResults(movieResults);

            if (filteredMovies.Count == 0)
            {
                return;
            }

            moviesFromFile?.AddRange(filteredMovies);

            _movieFileDataService.Write(_fileName, moviesFromFile);

            LoadMovies(filteredMovies, isAppend);
        }

        private List<MovieResult> SearchFromFile(ref List<MovieResult> moviesFromFile, ref bool isAppend)
        {
            if (File.Exists(_fileName))
            {
                moviesFromFile = _movieFileDataService.Read(_fileName) ?? new List<MovieResult>();

                return moviesFromFile.Where(mff => mff.Title.ToLower().Contains(Text.ToLower())).ToList();
            }

            moviesFromFile = new List<MovieResult>();
            return null;
        }

        private List<MovieResult> FilterMovieResults(List<MovieResult> movieResults)
        {
            var imdbIds = Movies.Select(m => m.ImdbId).ToList();

            return new List<MovieResult>(movieResults.Where(mr => !imdbIds.Contains(mr.imdbID)));
        }

        private void LoadMovies(List<MovieResult> movieResults, bool append = false)
        {
            if (!append)
                Movies.Clear();

            foreach (var movie in _apiResultConverter.ConvertMovies(movieResults))
            {
                Movies.Add(new MovieWrapper(movie));
            }

            if(append)
                Movies.Reverse();
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