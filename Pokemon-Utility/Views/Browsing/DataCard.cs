using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Platform;
using Brushes = Avalonia.Media.Brushes;
using Avalonia.Media.Imaging;

namespace Pokemon_Utility.Views.Browsing
{
    /// <summary>
    /// DataCard
    ///     dataCard
    ///         pokemonPic
    ///             pnj
    ///         id_name_icon_Border
    ///             id_name_icon
    ///                 id_name
    ///                 typePic
    ///                     typeIcon1
    ///                     typeIcon2
    /// </summary>
	public class DataCard : Border
    {
        StackPanel dataCard;
        StackPanel pic;
        Image pokemonPic;
        public int ID;
        TextBlock id_name;
        Border id_name_icon_Border;
        StackPanel id_name_icon;
        StackPanel typePic;
        Image typeIcon1;
        Image typeIcon2;

        public DataCard(string Type1, string Type2, int id, string name)
		{
            //change the datacard properties
            this.Margin = Thickness.Parse("30");
            this.CornerRadius = CornerRadius.Parse("5");
            this.Width = 700 / 3;
            this.Height = 150;
            this.ID = id;
            switch (Type1)
            {
                //the color according to the type of pokemon
                case "fire":
                    this.Background = Brushes.OrangeRed;
                    break;
                case "water":
                    this.Background = Brushes.CornflowerBlue;
                    break;
                case "electric":
                    this.Background = Brushes.Yellow;
                    break;
                case "grass":
                    this.Background = Brushes.LightGreen;
                    break;
                case "ice":
                    this.Background = Brushes.PowderBlue;
                    break;
                case "fighting":
                    this.Background = Brushes.Brown;
                    break;
                case "poison":
                    this.Background = Brushes.Purple;
                    break;
                case "ground":
                    this.Background = Brushes.SandyBrown;
                    break;
                case "flying":
                    this.Background = Brushes.Lavender;
                    break;
                case "psychic":
                    this.Background = Brushes.Pink;
                    break;
                case "bug":
                    this.Background = Brushes.DarkOliveGreen;
                    break;
                case "rock":
                    this.Background = Brushes.RosyBrown;
                    break;
                case "ghost":
                    this.Background = Brushes.DarkMagenta;
                    break;
                case "dragon":
                    this.Background = Brushes.MediumPurple;
                    break;
                case "dark":
                    this.Background = Brushes.DimGray;
                    break;
                case "steel":
                    this.Background = Brushes.SteelBlue;
                    break;
                case "fairy":
                    this.Background = Brushes.HotPink;
                    break;
                default:
                    this.Background = Brushes.Gray;
                    break;
            }

            dataCard = new StackPanel();
            //set the dataCard as the children of the dataCard_Border
            this.Child = dataCard;

            //change the dataCard properties
            dataCard.Orientation = Orientation.Horizontal;

            pic = new StackPanel();
            //set the pic as the children of the dataCard
            dataCard.Children.Add(pic);

            //change the pic properties
            pic.Width = this.Width / 2;
            pic.VerticalAlignment = VerticalAlignment.Center;

            pokemonPic = new Image();
            if(id<=1010)
            {
                pokemonPic.Source = new Bitmap(AssetLoader.Open(new Uri($"avares://Pokemon-Utility/Assets/pokemon/{id}.png")));

            }
            else
            {
                pokemonPic.Source = new Bitmap(AssetLoader.Open(new Uri($"avares://Pokemon-Utility/Assets/pokemon/1.png")));

            }
            pic.Children.Add(pokemonPic);

            id_name_icon_Border = new Border();
            //set the id_name_icon_Border as the children of the dataCard
            dataCard.Children.Add(id_name_icon_Border);

            //change the id_name_icon_border properties
            id_name_icon_Border.Background = Brushes.WhiteSmoke;
            id_name_icon_Border.CornerRadius = new CornerRadius(0, 5, 5, 0);

            id_name_icon = new StackPanel();
            //set the id_name_icon as the children of the id_name_icon_Border
            id_name_icon_Border.Child = id_name_icon;

            //change the id_name_icon properties
            id_name_icon.Width = this.Width / 2;
            id_name_icon.VerticalAlignment = VerticalAlignment.Stretch;
            id_name_icon.Orientation = Orientation.Vertical;

            id_name = new TextBlock();
            //set the id_name as the children of the id_name_icon
            id_name_icon.Children.Add(id_name);

            //change the id_name properties
            id_name.Foreground = Brushes.Black;
            id_name.Margin = Thickness.Parse("10");
            id_name.Text = $"#{id}\n{name}";

            typePic = new StackPanel();
            //set the typePic as the children of the id_name_icon
            id_name_icon.Children.Add(typePic);

            //change the typePic properties
            typePic.Orientation = Orientation.Horizontal;
            typePic.VerticalAlignment = VerticalAlignment.Stretch;
            typePic.HorizontalAlignment = HorizontalAlignment.Center;

            typeIcon1 = new Image();
            typeIcon1.Source = new Bitmap(AssetLoader.Open(new Uri($"avares://Pokemon-Utility/Assets/Types/{Type1}.png")));
            //set the typeIcon1 as the children of the typePic
            typePic.Children.Add(typeIcon1);

            //change the typeIcon1 properties
            typeIcon1.Width = typeIcon1.Height = 40;
            typeIcon1.HorizontalAlignment = HorizontalAlignment.Left;
            typeIcon1.VerticalAlignment = VerticalAlignment.Bottom;
            typeIcon1.Margin = new Thickness(10, 15, 2.5, 0);

            if (Type2 != "null")
            {
                typeIcon2 = new Image();
                typeIcon2.Source = new Bitmap(AssetLoader.Open(new Uri($"avares://Pokemon-Utility/Assets/Types/{Type2}.png")));
                //set the typeIcon2 as the children of the typePic
                typePic.Children.Add(typeIcon2);

                //change the typeIcon2 properties
                typeIcon2.Width = typeIcon1.Height = 40;
                typeIcon2.HorizontalAlignment = HorizontalAlignment.Right;
                typeIcon2.VerticalAlignment = VerticalAlignment.Bottom;
                typeIcon2.Margin = new Thickness(5, 15, 10, 0);
            }
        }
    }
}