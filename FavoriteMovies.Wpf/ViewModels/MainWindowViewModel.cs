using System.Windows.Input;
using FavoriteMovies.Wpf.Events;
using Prism.Commands;
using Prism.Events;

namespace FavoriteMovies.Wpf.ViewModels
{
    public class MainWindowViewModel:ObservableObject, IMainWindowViewModel
    {
        private readonly MovieDiscoverViewModel _movieDiscoverViewModel;
        private readonly MovieDetailViewModel _movieDetailViewModel;
        private readonly IEventAggregator _eventAggregator;
        private ObservableObject _currentViewModel;

        public MainWindowViewModel(MovieDiscoverViewModel movieDiscoverViewModel, MovieDetailViewModel movieDetailViewModel, IEventAggregator eventAggregator)
        {
            _movieDiscoverViewModel = movieDiscoverViewModel;
            _movieDetailViewModel = movieDetailViewModel;
            _eventAggregator = eventAggregator;

            LoadCommand = new DelegateCommand(OnLoadExecute);

            _eventAggregator.GetEvent<OpenMovieDetailViewEvent>().Subscribe(OnOpenMovieDetailView);
        }

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
            CurrentViewModel = vm;
        }

        private void OnOpenMovieDetailView(string imdbId)
        {
           SwitchViewModel(_movieDetailViewModel);
           _movieDetailViewModel.LoadMovieAsync(imdbId);
        }
    }
}