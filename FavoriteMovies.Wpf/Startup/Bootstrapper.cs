using Autofac;
using FavoriteMovies.OmdbApi.Services;
using FavoriteMovies.Wpf.ViewModels;
using FavoriteMovies.Wpf.Views;
using Prism.Events;

namespace FavoriteMovies.Wpf.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MovieService>().AsImplementedInterfaces();

            builder.RegisterType<MainWindowView>();

            builder.RegisterType<MainWindowViewModel>().As<IMainWindowViewModel>();
            builder.RegisterType<MovieDiscoverViewModel>();
            builder.RegisterType<MovieDetailViewModel>();

            builder.RegisterType<ApiResultConverter>();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            return builder.Build();
        }
    }
}