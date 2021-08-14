using Autofac;
using FavoriteMovies.OmdbApi.Services;
using FavoriteMovies.Wpf.ViewModels;
using FavoriteMovies.Wpf.Views;

namespace FavoriteMovies.Wpf.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MovieService>().AsImplementedInterfaces();

            builder.RegisterType<MainWindowView>();

            builder.RegisterType<MainWindowViewModel>();

            return builder.Build();
        }
    }
}