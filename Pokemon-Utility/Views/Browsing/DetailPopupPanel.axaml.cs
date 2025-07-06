using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PokeApiNet;
using Pokemon_Utility.Models.Context;
using Move = Pokemon_Utility.Models.Entity.Move;

namespace Pokemon_Utility.Views.Browsing;

public partial class DetailPopupPanel : Panel
{
    private int id;
    private string name;
    private string? type1;
    private string? type2;
    private int genderRate;
    private int catchRate;
    private List<Move> moveList = new List<Move>();
    public DetailPopupPanel()
    {
        InitializeComponent();
        HeaderBar.Background = Design.Color.FgBlue;
        MoveListPanel.Background = Design.Color.BgLightGray;
        typeText.Foreground = Design.Color.FgBlack;
        
        CloseButton.Click += (sender, args) => { (this.Parent as Panel).Children.Remove(this);};
    }

    public DetailPopupPanel(int id) : this()
    {
        this.id = id;
        // QueryForData();
        FetchApiForData();
        HeaderTextBox.Text = string.Format("#{0} Loading...",id);
        PokemonImage.Source = new Bitmap(AssetLoader.Open(new Uri($"avares://Pokemon-Utility/Assets/pokemon/{id}.png")));
        // testText.Text = id+" "+name +" "+catchRate+" "+ genderRate+"\nType:"+ type1+ (type2.IsNullOrEmpty()? "": type2);
        // testText.Text += "\n Moves:";
        // foreach (var move in moveList)
        // {
        //     testText.Text += move.Name+"\n";
        // }
    }

    private async Task QueryForData()
    {
        
        MainContext.Query(
            onReceive: async context =>
            {
                var pokemon = context.Pokemons.Find(id);
                this.name = pokemon.Name;
                this.genderRate = (int)pokemon.GenderRate;
                this.catchRate = (int)pokemon.CaptureRate;
                var types = await context.PokemonTypes.Where(s => s.PokemonId == id).ToListAsync();
                type1 = types[0].Name;
                if (types.Count >1)
                {
                    type2 = types[1].Name;

                }


                moveList = await (from pm in context.PokemonMoves.Where(s => s.PokemonId == id)
                    join m in context.Moves on pm.MoveId equals m.Id
                    select m).Distinct().ToListAsync();
                
                
                // Set up
                HeaderTextBox.Text = string.Format("#{0} {1}",id,name);
                typeText.Text = type1 +"/"+ ((type2.IsNullOrEmpty()) ? "" : type2);
                bool bgFlip = true;
                foreach (var move in moveList)
                {
                    scrollViewerContent.Children.Add(new MoveCard(move.Name,move.Type,move.Power.ToString(),move.Accuracy.ToString(),move.Pp.ToString(),bgFlip));
                    bgFlip = !bgFlip;
                }

                Debug.WriteLine("Query Done");
                HeaderBar.Background = Design.Color.FgBlue;


                
            },
            onFailure: () => { }
        );
        Debug.WriteLine("Query Loaded");
    }

    private async Task FetchApiForData()
    {
        
        PokeApiNet.Pokemon pokemon = await MainContext.ApiClient.GetResourceAsync<PokeApiNet.Pokemon>(id);
        
        FetchMove(pokemon);
        
        // Set up
        HeaderTextBox.Text = string.Format("#{0} {1}",id,pokemon.Name);
        foreach (var type in pokemon.Types)
        {
            typePanel.Children.Add( new Image
            {
                Margin = new Thickness(20,0,0,0),
                Source = new Bitmap(AssetLoader.Open(new Uri($"avares://Pokemon-Utility/Assets/Types/{type.Type.Name}.png"))),
            });
        }
        string abiltities = "Ability:\t";
        foreach (var ability in pokemon.Abilities)
        {
            abiltities += ability.Ability.Name + "\t";
        }
        infoStackPanel.Children.Add( new TextBlock
        {
            Foreground = Design.Color.FgBlack,
            FontWeight = FontWeight.Bold,
            FontSize = 30,
            Text = abiltities,
        });
        Grid statGrid = new Grid
        {
            ColumnDefinitions = new ColumnDefinitions("140,1*"),
            RowDefinitions = new RowDefinitions("1*,1*,1*,1*,1*,1*"),
            Height = 300,
        };
        infoStackPanel.Children.Add(statGrid);
        for (int i = 0; i < 6; i++)
        {
            TextBlock statName = new TextBlock
            {
                Foreground = Design.Color.FgBlack,
                FontSize = 30,
            };
            switch (i)
            {
                case 0 : statName.Text = "HP"; break;
                case 1 : statName.Text = "ATK"; break;
                case 2 : statName.Text = "DEF"; break;
                case 3 : statName.Text = "S.ATK"; break;
                case 4 : statName.Text = "S.DEF"; break;
                case 5 : statName.Text = "SPD"; break;
                default: break;
            }
            statGrid.Children.Add(statName);
            // var statValue = new TextBlock
            // {
            //     Text = pokemon.Stats[i].BaseStat.ToString()+" ",
            //     HorizontalAlignment = HorizontalAlignment.Right,
            //     FontSize = 30,
            // };
            // statGrid.Children.Add(statValue);
            // Grid.SetColumn(statValue,0);
            // Grid.SetRow(statValue,i);
            Grid.SetColumn(statName,0);
            Grid.SetRow(statName,i);
            // Border statBar = new Border
            // {
            //     Background = Design.Color.FgBlue,
            //     CornerRadius = new CornerRadius(10),
            //     Width = pokemon.Stats[i].BaseStat*4,
            //     HorizontalAlignment = HorizontalAlignment.Left,
            //     Margin = new Thickness(0,0,0,10)
            // };
            
            
            if (pokemon.Stats[i].BaseStat < 15)
            {
                var rL = new RelativePanel();
                RightChartBar statBar = new RightChartBar(pokemon.Stats[i].BaseStat);
                rL.Children.Add(statBar);
                var statText = new TextBlock
                {
                    Text = pokemon.Stats[i].BaseStat.ToString(),
                    FontSize = 18,
                    Foreground = Design.Color.FgBlue,
                    VerticalAlignment = VerticalAlignment.Center
                };
                rL.Children.Add(statText);
                RelativePanel.SetRightOf(statText, statBar);
                statGrid.Children.Add( rL);
                Grid.SetColumn(rL,1);
                Grid.SetRow(rL,i);
            }
            else
            {
                RightChartBar statBar = new RightChartBar(pokemon.Stats[i].BaseStat);
                statGrid.Children.Add( statBar);
                Grid.SetColumn(statBar,1);
                Grid.SetRow(statBar,i);
            }

            
        }

        // foreach (var stat in pokemon.Stats)
        // {
        //     infoStackPanel.Children.Add( new TextBlock
        //     {
        //         FontWeight = FontWeight.Bold,
        //         FontSize = 30,
        //         Text = stat.Stat.Name +": " +stat.BaseStat,
        //     });
        // }
        
        
        

        Debug.WriteLine("Fetch Done");
    }
    

    private async Task FetchMove( PokeApiNet.Pokemon pokemon)
    {
        List<PokeApiNet.Move> allMoves = await MainContext.ApiClient.GetResourceAsync(pokemon.Moves.Select(move => move.Move));
        bool bgFlip = true;
        foreach (var move in allMoves)
        {
            scrollViewerContent.Children.Add(new MoveCard(move.Name,move.Type.Name,move.Power.ToString(),move.Accuracy.ToString(),move.Pp.ToString(),bgFlip));
            bgFlip = !bgFlip;
        }

        moveTitle.Children.Clear();
        moveTitle.Children.Add( new  MoveCard("Name","Type","Power","Acc","PP",false));

    }


}