using Avalonia;
using Avalonia.Controls;

namespace Pokemon_Utility.Views.Browsing;

public partial class RightChartBar : Panel
{
    public RightChartBar(double value)
    {
        InitializeComponent();
        bar.Background = Design.Color.FgBlue;
        this.Width = (value < 180) ? value * 3 : 180 * 3;
        if (value < 15)
        {
        }
        else
        {
            statNumber.Text = value.ToString();

        }

    }
}