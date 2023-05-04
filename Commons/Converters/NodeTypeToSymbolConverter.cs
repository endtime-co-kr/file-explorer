using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
#if false
namespace CFT.Views.Converters
{
    [ValueConversion(typeof(ExplorerTreeNode), typeof(SymbolIcon))]
    public class NodeTypeToSymbolConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if (((bool)value) == true)
            //{
            //    return Brushes.Red;
            //}
            //return Brushes.Green;
            //Icon icon = SystemIcons.WinLogo;
            eTreeNodeType nodeType = (eTreeNodeType)value;
            //if (string.IsNullOrEmpty(node.FullPath) == false && node.NodeType == eTreeNodeType.File)
            //{
            //    icon = System.Drawing.Icon.ExtractAssociatedIcon(node.FullPath);
            //}
            Wpf.Ui.Common.SymbolRegular sym = Wpf.Ui.Common.SymbolRegular.Empty;
            switch (nodeType)
            {
                case eTreeNodeType.Root:
                    sym = Wpf.Ui.Common.SymbolRegular.Desktop16;
                    break;
                case eTreeNodeType.Drive:
                    sym = Wpf.Ui.Common.SymbolRegular.HardDrive20;
                    break;
                case eTreeNodeType.Directory:
                    sym = Wpf.Ui.Common.SymbolRegular.Folder20;
                    break;
                case eTreeNodeType.File:
                    //sym = Wpf.Ui.Common.SymbolRegular.
                    break;
            }
            return sym;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //SolidColorBrush color = value as SolidColorBrush;
            //if (color != Brushes.Red)
            //{
            //    return true;
            //}
            return null;
        }
    }

}
#endif