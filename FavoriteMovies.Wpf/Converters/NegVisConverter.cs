using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FavoriteMovies.Wpf.Converters
{
    public class NegVisConverter:IValueConverter
    {
        public bool Negate { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Negate false for add
            // Negate true for remove

            var isFavorite = (bool) value;
            // Negate false
            // Is Favorite false
            // add visibility visible


            if (!Negate && !isFavorite)
                return Visibility.Visible;

            // negate false
            // is favorite true
            // and visibility collapsed

            if (!Negate && isFavorite)
                return Visibility.Collapsed;

            // negate true
            // is favorite false
            // remove visibility collapsed

            if (Negate && !isFavorite)
                return Visibility.Collapsed;

            // negate true
            // is favorite true
            // remove visibility visible

            if (Negate && isFavorite)
                return Visibility.Visible;

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}