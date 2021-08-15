using System.Windows.Input;
using FavoriteMovies.Wpf.Events;
using Prism.Commands;
using Prism.Events;

namespace FavoriteMovies.Wpf.ViewModels
{
    public class NavigationMenuViewModel:ObservableObject
    {
        private readonly IEventAggregator _eventAggregator;

        public NavigationMenuViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            OpenMovieDiscoverViewCommand = new DelegateCommand(OnOpenMovieDiscoverViewExecute);
            OpenFavoriteListViewCommand = new DelegateCommand(OnOpenFavoriteListViewExecute);
        }

        public ICommand OpenMovieDiscoverViewCommand { get; }
        public ICommand OpenFavoriteListViewCommand { get; }

        private void OnOpenMovieDiscoverViewExecute()
        {
            _eventAggregator.GetEvent<OpenMovieDiscoverViewEvent>().Publish();
        }

        private void OnOpenFavoriteListViewExecute()
        {
            _eventAggregator.GetEvent<OpenFavoriteListViewEvent>().Publish();
        }
    }
}