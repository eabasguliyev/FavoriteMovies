using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Documents;
using FavoriteMovies.Domain.Models;

namespace FavoriteMovies.Wpf.Converters
{
    public class ListToStringConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            dynamic values = null;

            if (value is List<Person> persons)
            {
                values = persons;
            }
            else if (value is List<Language> languages)
            {
                values = languages;
            }
            else if (value is List<Country> countries)
            {
                values = countries;
            }

            var strBuilder = new StringBuilder(parameter as String);

            for (int i = 0, length = values.Count; i < length; i++)
            {
                strBuilder.Append(values[i].Name);

                if (i != length - 1)
                    strBuilder.Append(", ");
            }

            return strBuilder.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}