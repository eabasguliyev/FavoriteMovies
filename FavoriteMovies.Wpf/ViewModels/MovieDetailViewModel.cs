using System;
using System.Windows.Input;
using FavoriteMovies.Domain.Models;
using FavoriteMovies.Domain.Services;
using FavoriteMovies.Domain.Services.Api;
using FavoriteMovies.EntityFramework.DatabaseNormalizer;
using FavoriteMovies.OmdbApi.Services;
using FavoriteMovies.Wpf.Wrappers;
using Prism.Commands;

namespace FavoriteMovies.Wpf.ViewModels
{
    public class MovieDetailViewModel:ObservableObject
    {
        private readonly IMovieService _movieService;
        private readonly IFavoriteMovieDataService _favoriteMovieDataService;
        private readonly DbEntityNormalizer _dbEntityNormalizer;
        private readonly ApiResultConverter _apiResultConverter;
        private MovieDetailWrapper _movie;
        private bool _entityNormalized;
        public MovieDetailViewModel(IMovieService movieService, IFavoriteMovieDataService favoriteMovieDataService, DbEntityNormalizer dbEntityNormalizer,
            ApiResultConverter apiResultConverter)
        {
            _movieService = movieService;
            _favoriteMovieDataService = favoriteMovieDataService;
            _dbEntityNormalizer = dbEntityNormalizer;
            _apiResultConverter = apiResultConverter;

            AddFavoriteCommand = new DelegateCommand(OnAddFavoriteExecuteAsync);
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

        public ICommand AddFavoriteCommand { get; }

        public async void LoadMovieAsync(string imdbId)
        {
            Movie = new MovieDetailWrapper(_apiResultConverter.ConvertMovieDetail(await _movieService.GetMovieAsync(imdbId)));
        }
        private async void OnAddFavoriteExecuteAsync()
        {
            if(!_entityNormalized)
            {
                _dbEntityNormalizer.MovieEntityNormalizer(Movie.Model);
                _entityNormalized = true;
            }

            await _favoriteMovieDataService.AddAsync(Movie.Model);
        }
    }
}