using System.Windows.Input;
using Prism.Commands;

namespace FavoriteMovies.Wpf.ViewModels
{
    public class MainWindowViewModel:ObservableObject, IMainWindowViewModel
    {
        private readonly MovieDiscoverViewModel _movieDiscoverViewModel;
        private ObservableObject _currentViewModel;

        public MainWindowViewModel(MovieDiscoverViewModel movieDiscoverViewModel)
        {
            _movieDiscoverViewModel = movieDiscoverViewModel;

            LoadCommand = new DelegateCommand(OnLoadExecute);
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
            CurrentViewModel = _movieDiscoverViewModel;
        }
    }
}