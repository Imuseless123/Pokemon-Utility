using Avalonia;
using Avalonia.Controls;

namespace Pokemon_Utility.Views.TeamBuilder;

public partial class LeftChartBar : Panel
{
    public LeftChartBar(int value)
    {
        InitializeComponent();
        if (value > 6)
        {
            this.Width = 6 * 40;
        }
        else
        {
            this.Width = value*40;
        }

        mutiplierTextBlock.Text = "x" + value;
        
    }
}