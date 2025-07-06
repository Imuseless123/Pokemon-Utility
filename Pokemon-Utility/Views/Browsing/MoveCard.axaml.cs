using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace Pokemon_Utility.Views.Browsing;

public partial class MoveCard : Grid
{
    public MoveCard()
    {
        InitializeComponent();
        this.Background = Design.Color.BgLightGray;
    }
    public MoveCard(string name, string type, string power, string accuracy, string pp , bool odd ) : this()
    {
        if (odd) this.Background = Design.Color.BgGray;
        // this.Children.Add( new TextBlock{ Text = name +"\t"+ type+"\t"+power+"\t"+accuracy+"\t"+pp , FontSize = 30});    
        nameBox.Text = name;
        powerBox.Text = type;
        typeBox.Text = power;
        ppBox.Text = pp;

    }
}