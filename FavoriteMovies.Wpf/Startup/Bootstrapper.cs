using System.Threading.Tasks;
using Autofac;
using FavoriteMovies.Domain.Models;
using FavoriteMovies.Domain.Services;
using FavoriteMovies.Domain.Services.Api.Results;
using FavoriteMovies.Domain.Services.File;
using FavoriteMovies.EntityFramework;
using FavoriteMovies.EntityFramework.DatabaseNormalizer;
using FavoriteMovies.OmdbApi.Services;
using FavoriteMovies.Wpf.Data;
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
            builder.RegisterType<NavigationMenuViewModel>();
            builder.RegisterType<FavoriteListViewModel>();

            builder.RegisterType<ApiResultConverter>();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<FavoriteMovieDataService>().As<IFavoriteMovieDataService>();

            //builder.RegisterType<ApplicationContext>();

            builder.RegisterType<DbEntityNormalizer>();

            builder.RegisterType<MovieFileDataService>().As<IFileDataService<MovieResult>>();

            // doesn't work as expected

            builder.Register(async context =>
            {
                return await Task.Factory.StartNew(() => new ApplicationContext());
            });

            return builder.Build();
        }
    }
}