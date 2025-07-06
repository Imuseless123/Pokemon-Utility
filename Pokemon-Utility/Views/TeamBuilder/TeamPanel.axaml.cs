using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Media;
using Pokemon_Utility.Controllers;
using Pokemon_Utility.Models.Context;

namespace Pokemon_Utility.Views.TeamBuilder
{
    public partial class TeamPanel : Panel
    {
        private List<PokemonInfoTeam> _pokemonList;

        public TeamPanel()
        {
            InitializeComponent();
        }

        public TeamPanel(List<PokemonInfoTeam> pokemonList) : this()
        {
            _pokemonList = pokemonList;
            InitUI();
        }

        private void InitUI()
        {
            // Xóa các controls cũ nếu có
            this.Children.Clear();

            // Tạo WrapPanel để chứa các Pokemon
            
            int rowSeparation = 0;
            StackPanel upperRow = new StackPanel
            {
                Orientation = Orientation.Horizontal,
            };
            StackPanel lowerRow = new StackPanel
            {
                Orientation = Orientation.Horizontal,
            };
            StackPanel teamOuterPanel = new StackPanel
            {
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Children = { upperRow, lowerRow}
            };
            foreach (var pokemon in _pokemonList)
            {
                rowSeparation++;
                

                // Create delete button
                Button deleteButton = new Button
                {
                    Content = "\u00d7",
                    Background = Design.Color.BgGray,
                    Foreground = Brushes.White,
                    Height = 26,
                    Width = 26,
                    CornerRadius = new CornerRadius(16),
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                };
                deleteButton.Click += (sender, args) =>
                {
                    MainContext.Query(
                        onReceive: context =>
                        {
                            context.TeamPokemons.Remove(context.TeamPokemons.Find(pokemon.MovesetId));
                            context.SaveChanges();
                        },
                        onFailure: () => { });
                };

                
                Bitmap pokemonImage = new Bitmap(AssetLoader.Open(new Uri($"avares://Pokemon-Utility/Assets/pokemon/{pokemon.Id}.png")));
                Image imgPokemon = new Image
                {
                    Height = 200,
                    Width = 200,
                    Source = pokemonImage,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.Uniform,
                };
                // Tạo control hiển thị hình ảnh
                Border imageBorder = new Border
                {
                    Height = 200,
                    Width = 200,
                    Margin = new Thickness(0,10,0,10),
                    CornerRadius = new CornerRadius(100),
                    Background = Brushes.White,
                    Child = imgPokemon,
                };
                // Tạo control hiển thị tên Pokemon
                Label lblPokemonName = new Label();
                lblPokemonName.Content = pokemon.Name;
                lblPokemonName.FontSize = 20;
                lblPokemonName.FontWeight = FontWeight.Bold;
                lblPokemonName.Foreground = Brushes.White;
                lblPokemonName.HorizontalAlignment = HorizontalAlignment.Center;
                lblPokemonName.VerticalAlignment = VerticalAlignment.Center;
                
                Border labelBorder = new Border
                {
                    CornerRadius = new CornerRadius(20),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Background = Design.Color.FgBlue,
                    Child = lblPokemonName,
                };
                
                Grid grid = new Grid
                {
                    RowDefinitions = new RowDefinitions("220,80"),
                    Children = { imageBorder,labelBorder },
                };
                Grid.SetRow(labelBorder,1);
                Border cardBorder = new Border
                {
                    Height = 300,
                    Width = 220,
                    CornerRadius = new CornerRadius(20),
                    Background = Design.Color.BgLightGray,
                    Child = grid,
                };
                Panel cardPanel = new Panel
                {
                    Margin = new Thickness(20),
                    Children = { cardBorder, deleteButton  }
                };
                if (rowSeparation <= 3)
                {
                    upperRow.Children.Add(cardPanel);
                }
                else
                {
                    lowerRow.Children.Add(cardPanel);
                }
                
            }

            // Thêm WrapPanel vào TeamPanel
            this.Children.Add(teamOuterPanel);
        }
        
    }
}