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
            var people = value as List<Person>;

            var strBuilder = new StringBuilder(parameter as String);

            for (int i = 0, length = people.Count; i < length; i++)
            {
                strBuilder.Append(people[i].Name);

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