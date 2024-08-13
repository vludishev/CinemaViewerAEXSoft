using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.App.Converters
{

    public class DateTimeToFancyAgoConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is DateTime publishingDate) {
                TimeSpan diff = DateTime.Now.Subtract(publishingDate);
                if (diff.Days > 0)
                {
                    return $"{diff.Days} days ago";
                }
                else
                {
                    return $"{diff.Hours} hours ago";
                }
            }

            throw new InvalidCastException($"Parameter {nameof(value)} " +
                $"isn't DateTime in method {nameof(DateTimeToFancyAgoConverter)}");
        }

        // Нужно его реализовать
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
