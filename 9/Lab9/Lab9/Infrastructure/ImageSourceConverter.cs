using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace Lab9.Infrastructure
{
    class ImageSourceConverter : IValueConverter//для отображения картинок
    {
        string imageDirectory = Directory.GetCurrentDirectory();//берет текущую директорию,те из папки где лежит exe

        string ImageDirectory
        {
            get
            {
                return Path.Combine(imageDirectory, "images");
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

