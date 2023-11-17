using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Layout;
using PokemonUtility;
using PokemonUtility.Views.Browsing;
using System;
using Avalonia.Input;

namespace Pokemon_Utility.Views.Browsing;

public partial class BrowsingView : Panel
{
    public BrowsingView()
    {
        InitializeComponent();

        //set the column and row to auto size
        GridView.ColumnDefinitions.Add(new ColumnDefinition(1, GridUnitType.Star));
        GridView.RowDefinitions.Add(new RowDefinition(1, GridUnitType.Auto));
        GridView.RowDefinitions.Add(new RowDefinition(2, GridUnitType.Auto));
        GridView.RowDefinitions.Add(new RowDefinition(3, GridUnitType.Star));

        //set up the UI
        BrowsingQuery a = new BrowsingQuery();
        string[,] pokemons = a.PokemonQuery_byName("P");
        int nOfPokemon = a.NOfPokemonFound;

        this.BrowsingBar();
        this.PokemonFoundTextblock(nOfPokemon);
        this.PokemonList(nOfPokemon, pokemons);

        //string[,] b = {{"1", "1", "1" },{ "1", "1", "1" }, {"1", "1", "1" },{ "1",
        //"1","1" },{"1","1","1" },{"1","1","1" },{"1","1","1"} };
        //this.PokemonList(21, b);
    }

    //method to create BrowsingBar
    void BrowsingBar()
    {
        StackPanel browsingBar = new StackPanel();
        //set the browsingBar as the children of the BrowsingView
        GridView.Children.Add(browsingBar);
        //set the browsingBar as the 1st row of the BrowsingView
        Grid.SetRow(browsingBar, 0);

        //change the browsingBar properties
        browsingBar.Height = 80;
        browsingBar.HorizontalAlignment = HorizontalAlignment.Stretch;
        browsingBar.Background = Brushes.Gray;

        TextBox searchBar = new TextBox();
        //set the searchBar as the children of the browsingBar
        browsingBar.Children.Add(searchBar);

        //change the searchBar properties
        searchBar.Height = browsingBar.Height/1.5;
        searchBar.Width = 900;
        searchBar.CornerRadius = CornerRadius.Parse("30");
        searchBar.Margin = new Thickness(10, 13, 10, 10);
        searchBar.VerticalAlignment = VerticalAlignment.Center;
        searchBar.HorizontalAlignment = HorizontalAlignment.Left;
        searchBar.VerticalContentAlignment = VerticalAlignment.Center;

        //create an event when the user input key word
        //searchBar.KeyUp += userInbutKeyWord;
    }

    //the event when the user input key word
    //public void userInbutKeyWord(object? sender, Avalonia.Input.KeyEventArgs e)
    //{
    //    if (e.Key == Key.Enter)
    //    {
    //        GridView.Children.RemoveAt(1);
    //        GridView.Children.RemoveAt(1);
            
    //        TextBox textBox = (TextBox)sender;
    //        string userInput = textBox.Text;

    //        BrowsingQuery a = new BrowsingQuery();
    //        int nOfPokemon = a.NOfPokemonFound;
    //        string[,] pokemons = a.PokemonQuery_byName(userInput);

    //        this.PokemonFoundTextblock(nOfPokemon);
    //        this.PokemonList(nOfPokemon, pokemons);
    //    }
    //}

    void PokemonFoundTextblock(int nOfPokemonFound)
    {
        TextBlock pokemonFound_Textblock = new TextBlock();
        //set the pokemonList_ScrollViewer as the children of the BrowsingView
        GridView.Children.Add(pokemonFound_Textblock);
        //set the pokemonList_ScrollViewer as the 3rd row of the BrowsingView
        Grid.SetRow(pokemonFound_Textblock, 1);

        //change the PokemonFound_Textblock properties
        pokemonFound_Textblock.Background = Brushes.White;
        pokemonFound_Textblock.Text = $"\n{nOfPokemonFound} Pokemon found";
        pokemonFound_Textblock.Foreground = Brushes.Black;
        pokemonFound_Textblock.TextAlignment = TextAlignment.Center;
    }

    //method to create the PokemonList
    void PokemonList(int nOfPokemonFound, string[,] pokemonFound)
    {
        ScrollViewer pokemonList_ScrollViewer = new ScrollViewer();
        //set the pokemonList_ScrollViewer as the children of the BrowsingView
        GridView.Children.Add(pokemonList_ScrollViewer);
        //set the pokemonList_ScrollViewer as the 3rd row of the BrowsingView
        Grid.SetRow(pokemonList_ScrollViewer, 2);

        //change the pokemonList_ScrollViewer properties
        pokemonList_ScrollViewer.Background = Brushes.White;
        pokemonList_ScrollViewer.VerticalAlignment = VerticalAlignment.Stretch;
        pokemonList_ScrollViewer.HorizontalAlignment = HorizontalAlignment.Stretch;
        
        StackPanel pokemonList = new StackPanel();
        //show the dataCards on the pokemonList
        int nOfDataCardRow = nOfPokemonFound % 4 == 0 ? (nOfPokemonFound / 4) : (nOfPokemonFound / 4 + 1);
        int index = 0;
        for (int i = 0; i < nOfDataCardRow; i++)
        {
            StackPanel pokemonRow = new StackPanel();

            //change the pokemonRow properties
            pokemonRow.HorizontalAlignment = HorizontalAlignment.Center;
            pokemonRow.Orientation = Orientation.Horizontal;

            //add the dataCards to the pokemonRow
            for (int y = 0; y < 4; y++)
            {
                if (nOfPokemonFound == 0)
                {
                    break;
                }
                DataCard dataCard = new DataCard();
                Border dataCard_Border = dataCard.SetDataCard(pokemonFound[i,2], int.Parse(pokemonFound[index,0]), pokemonFound[index,1]);
                pokemonRow.Children.Add(dataCard_Border);

                //update index
                nOfPokemonFound--;
                index++;
            }
            pokemonList.Children.Add(pokemonRow);
        }

        //set the pokemonList as the children of the pokemonList_ScrollViewer
        pokemonList_ScrollViewer.Content = pokemonList;
    }
}