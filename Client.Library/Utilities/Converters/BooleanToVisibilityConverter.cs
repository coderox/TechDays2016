using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Client.Utilities.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public bool IsNegative { get; set; } = false;

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool actualValue = (bool)value;
            if (IsNegative) {
                return actualValue ? Visibility.Collapsed : Visibility.Visible;
            }
            return actualValue ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
