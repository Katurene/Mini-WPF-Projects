using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace Lab9.Infrastructure
{
    class ImageSourceConverter : IValueConverter
    {
        string imageDirectory = Directory.GetCurrentDirectory();
        string ImageDirectory
        {
            get
            {
                return Path.Combine(imageDirectory, "Images");
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Path.Combine(ImageDirectory, (string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

