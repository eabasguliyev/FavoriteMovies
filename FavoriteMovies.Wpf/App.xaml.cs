using System;
using System.Windows;
using Autofac;
using FavoriteMovies.Wpf.Startup;
using FavoriteMovies.Wpf.ViewModels;
using FavoriteMovies.Wpf.Views;

namespace FavoriteMovies.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();

            var container = bootstrapper.Bootstrap();

            var window = container.Resolve<MainWindowView>();

            window.DataContext = container.Resolve<IMainWindowViewModel>();

            window.Show();
        }
    }
}