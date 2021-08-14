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

        public string Title => Model.Title;

        public string PosterLink => Model.PosterLink;

        public string ImdbId => Model.ImdbId;

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