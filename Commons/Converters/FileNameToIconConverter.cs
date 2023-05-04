using Commons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace Converters
{
    [ValueConversion(typeof(string), typeof(Bitmap))]
    public class FileNameToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Icon? icon = SystemIcons.WinLogo;
            string filePath = (string)value;
            if (string.IsNullOrEmpty(filePath) == false && File.Exists(filePath) == true)
            {
                icon = Icon.ExtractAssociatedIcon(filePath);
            }
            else
            {
                icon = DefaultIcons.FolderLarge;
            }
            icon = icon == null ? SystemIcons.WinLogo : icon;
            return Imaging.CreateBitmapSourceFromHIcon(icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return SystemIcons.WinLogo;
        }
    }
}
