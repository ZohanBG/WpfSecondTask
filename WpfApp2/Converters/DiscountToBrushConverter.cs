using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace DiscountApp.Converters
{
    public class DiscountToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is float discount)
            {
                // Clamp discount between 0 and 100
                discount = Math.Max(0, Math.Min(100, discount));

                // Map 0–100% discount to red value 0–255
                byte red = (byte)(255 * (discount / 100.0f));

                return new SolidColorBrush(Color.FromRgb(red, 0, 0));
            }

            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
    