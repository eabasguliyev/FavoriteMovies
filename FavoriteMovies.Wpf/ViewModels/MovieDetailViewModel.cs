using System;
using System.Windows.Input;
using FavoriteMovies.Domain.Models;
using FavoriteMovies.Domain.Services;
using FavoriteMovies.Domain.Services.Api;
using FavoriteMovies.Domain.Services.Api.Results;
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
        private bool _isFavorite;
        public MovieDetailViewModel(IMovieService movieService, IFavoriteMovieDataService favoriteMovieDataService, DbEntityNormalizer dbEntityNormalizer,
            ApiResultConverter apiResultConverter)
        {
            _movieService = movieService;
            _favoriteMovieDataService = favoriteMovieDataService;
            _dbEntityNormalizer = dbEntityNormalizer;
            _apiResultConverter = apiResultConverter;

            AddFavoriteCommand = new DelegateCommand(OnAddFavoriteExecuteAsync);
            RemoveFavoriteCommand = new DelegateCommand(OnRemoveFavoriteExecuteAsync);
            //LoadCommand = new DelegateCommand(OnLoadExecuteAsync);
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

        public bool IsFavorite
        {
            get => _isFavorite;
            private set
            {
                _isFavorite = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddFavoriteCommand { get; }
        public ICommand RemoveFavoriteCommand { get; }
        //public ICommand LoadCommand { get; }

        public async void LoadMovieAsync(string imdbId)
        {
            Movie = new MovieDetailWrapper(_apiResultConverter.ConvertMovieDetail(await _movieService.GetMovieAsync(imdbId)));

            IsFavorite = await _favoriteMovieDataService.IsExistAsync(Movie.Model);
        }
        private async void OnAddFavoriteExecuteAsync()
        {
            _dbEntityNormalizer.MovieEntityNormalizer(Movie.Model);

            await _favoriteMovieDataService.AddAsync(Movie.Model);
            IsFavorite = true;
        }
        private async void OnRemoveFavoriteExecuteAsync()
        {
            await _favoriteMovieDataService.RemoveAsync(Movie.Model);
            Movie.Model.Id = 0;
            IsFavorite = false;
        }
    }
}