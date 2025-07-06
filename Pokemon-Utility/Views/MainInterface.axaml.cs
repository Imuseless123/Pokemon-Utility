using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Styling;
using PokeApiNet;
using Pokemon_Utility.Models.Context;
using Pokemon_Utility.Views.Browsing;
using Pokemon_Utility.Views.TeamBuilder;

namespace Pokemon_Utility.Views;

public partial class MainInterface : Panel
{
   
    
    private BrowsingView browsingView = new Browsing.BrowsingView();
    private TeamView teamView = new TeamBuilder.TeamView();
    public MainInterface()
    {
        InitializeComponent();
        TabBar.Items.Add("Browse");
        TabBar.Items.Add("Type");
        TabBar.Items.Add("Team");
        TabBar.Foreground = Design.Color.FgBlue;
        TabBar.SelectedIndex = 0;
        LogoBox.Background = Design.Color.FgBlue;
        SideBar.Background = Design.Color.FgLightBlue;
        // LogoImage.Source = new Bitmap(AssetLoader.Open(new Uri("avares://Pokemon-Utility/Assets/pokemon/1.png")));
        
        //
        if (MainContext.Connected)
        {
        
            this.Children.Add(browsingView);
        
            TabBar.SelectionChanged += OnSelect;
        
        }

        // MainContext.Query(
        //     onReceive: async context =>
        //     {
        //         this.Children.Add(browsingView);
        //         TabBar.SelectionChanged += OnSelect;
        //     },
        //     onFailure: () => { }
        // );
    }

    private void OnSelect(object? sender, SelectionChangedEventArgs e)
    {
        if ((sender as ListBox).SelectedIndex == 0)
        {
            this.Children[1] = browsingView;
        }
        else if((sender as ListBox).SelectedIndex == 2)
        {
            this.Children[1] = teamView;
            teamView.SetUp();
        }
        else
        {
            this.Children[1] = new TypeChart();
        }
    }
    

}