using System;
using FavoriteMovies.Domain.Models;

namespace FavoriteMovies.Wpf.Wrappers
{
    public class MovieWrapper:ModelWrapper<Movie>
    {
        public MovieWrapper(Movie model) : base(model)
        {
            ShortTitle = GetShortTitle(model.Title);
        }

        public string ShortTitle { get; }

        public string Title
        {
            get => Model.Title;
            set
            {
                Model.Title = value;
                OnPropertyChanged();
            }
        }

        public string PosterLink
        {
            get => Model.PosterLink;
            set
            {
                Model.PosterLink = value;
                OnPropertyChanged();
            }
        }

        public string ImdbId
        {
            get => Model.ImdbId;
            set
            {
                Model.ImdbId = value;
                OnPropertyChanged();
            }
        }

        private string GetShortTitle(string title)
        {
            if (String.IsNullOrWhiteSpace(title))
                return "Unknown";

            if(title.Length >= 15)
                return title.Substring(0, 15) + "...";

            return title;
        }

    }
}