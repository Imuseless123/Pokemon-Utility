using System.Drawing;
using Avalonia;
using Avalonia.Media;
using Brush = Avalonia.Media.Brush;
namespace Pokemon_Utility.Views;
public class Design
{
    public class Color
    {
        public static IBrush FgBlue = Brush.Parse("#529AFD");
        public static IBrush FgLightBlue = Brush.Parse("#77B9FF");
        public static IBrush BgWhite = Brush.Parse("#F5F5F5");
        public static IBrush BgLightGray = Brush.Parse("#E9E9E9");
        public static IBrush BgGray = Brush.Parse("#C4C4C4");
        public static IBrush FgBlack = Brush.Parse("#434343");
    }
}