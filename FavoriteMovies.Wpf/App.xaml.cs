using System;
using System.Windows;
using FavoriteMovies.Wpf.Startup;

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
            
        }
    }
}