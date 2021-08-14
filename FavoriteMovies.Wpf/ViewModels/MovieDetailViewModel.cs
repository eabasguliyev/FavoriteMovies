using System;
using FavoriteMovies.Domain.Models;
using FavoriteMovies.Domain.Services;
using FavoriteMovies.OmdbApi.Services;
using FavoriteMovies.Wpf.Wrappers;

namespace FavoriteMovies.Wpf.ViewModels
{
    public class MovieDetailViewModel:ObservableObject
    {
        private readonly IMovieService _movieService;
        private readonly ApiResultConverter _apiResultConverter;
        private MovieDetailWrapper _movie;

        public MovieDetailViewModel(IMovieService movieService, ApiResultConverter apiResultConverter)
        {
            _movieService = movieService;
            _apiResultConverter = apiResultConverter;
        }

        public MovieDetailWrapper Movie
        {
            get => _movie;
            set
            {
                _movie = value;
                OnPropertyChanged();
            }
        }

        public async void LoadMovieAsync(string imdbId)
        {   
            Movie = new MovieDetailWrapper(_apiResultConverter.ConvertMovieDetail(await _movieService.GetMovieAsync(imdbId)));
        }
    }
}