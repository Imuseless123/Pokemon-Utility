using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace Pokemon_Utility.Views.TeamBuilder;

public partial class TypeChartBar : Grid
{
    public TypeChartBar(string type, int value)
    {
        InitializeComponent();
        typeIcon.Source =
            new Bitmap(AssetLoader.Open(new Uri($"avares://Pokemon-Utility/Assets/Types/{type}.png")));
        if (value > 0)
        {
            RightChartBar rightBar = new RightChartBar(value);
            this.Children.Add(rightBar);
            Grid.SetColumn(rightBar,2);
        }
        if (value < 0)
        {
            LeftChartBar leftBar = new LeftChartBar(value*(-1));
            this.Children.Add(leftBar);
            Grid.SetColumn(leftBar,0);
        }

        


        // statNumber.Text = value.ToString();
    }
}