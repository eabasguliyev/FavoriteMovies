using System;
using System.Windows.Input;
using FavoriteMovies.Wpf.Events;
using Prism.Commands;
using Prism.Events;

namespace FavoriteMovies.Wpf.ViewModels
{
    public class MainWindowViewModel:ObservableObject, IMainWindowViewModel
    {
        private readonly MovieDiscoverViewModel _movieDiscoverViewModel;
        private readonly Func<MovieDetailViewModel> _movieDetailViewModelCreator;
        private MovieDetailViewModel _movieDetailViewModel;
        private readonly IEventAggregator _eventAggregator;
        private ObservableObject _currentViewModel;

        public MainWindowViewModel(MovieDiscoverViewModel movieDiscoverViewModel,
            Func<MovieDetailViewModel> movieDetailViewModelCreator, NavigationMenuViewModel navigationMenuViewModel, IEventAggregator eventAggregator)
        {
            _movieDiscoverViewModel = movieDiscoverViewModel;
            _movieDetailViewModelCreator = movieDetailViewModelCreator;
            _eventAggregator = eventAggregator;

            NavigationMenuViewModel = navigationMenuViewModel;
            LoadCommand = new DelegateCommand(OnLoadExecute);

            _eventAggregator.GetEvent<OpenMovieDetailViewEvent>().Subscribe(OnOpenMovieDetailView);
            _eventAggregator.GetEvent<OpenMovieDiscoverViewEvent>().Subscribe(OnOpenMovieDiscoverView);
        }


        public NavigationMenuViewModel NavigationMenuViewModel { get; }

        public ObservableObject CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadCommand { get; }

        private void OnLoadExecute()
        {
            SwitchViewModel(_movieDiscoverViewModel);
        }

        private void SwitchViewModel(ObservableObject vm)
        {
            if (CurrentViewModel == vm)
                return;

            CurrentViewModel = vm;
        }

        private void OnOpenMovieDetailView(string imdbId)
        {
            _movieDetailViewModel = _movieDetailViewModelCreator();
           SwitchViewModel(_movieDetailViewModel);
           _movieDetailViewModel.LoadMovieAsync(imdbId);
        }

        private void OnOpenMovieDiscoverView()
        {
            SwitchViewModel(_movieDiscoverViewModel);
        }
    }
}