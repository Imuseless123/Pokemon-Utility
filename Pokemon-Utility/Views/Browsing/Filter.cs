using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;

namespace Pokemon_Utility.Views.Browsing
{
    public class Filter: Panel
    {
        string selectedItem;
        ComboBox filter;

        public string SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; }
        }

        public Filter()
        {
            //change the Filter class properties
            this.Height = 60;
            this.Width = 100;

            filter = new ComboBox();
            filter.Foreground = Brushes.White;
            filter.FontSize = 20;
            //set the filter as the children of the Filter class
            this.Children.Add(filter);

            //add the items to the filter
            filter.Items.Add("all");
            filter.Items.Add("normal");
            filter.Items.Add("water");
            filter.Items.Add("electric");
            filter.Items.Add("grass");
            filter.Items.Add("ice");
            filter.Items.Add("fighting");
            filter.Items.Add("poison");
            filter.Items.Add("ground");
            filter.Items.Add("flying");
            filter.Items.Add("psychic");
            filter.Items.Add("bug");
            filter.Items.Add("rock");
            filter.Items.Add("ghost");
            filter.Items.Add("dragon");
            filter.Items.Add("dark");
            filter.Items.Add("steel");
            filter.Items.Add("fairy");

            //change the filter properties
            filter.VerticalAlignment = VerticalAlignment.Center;
            filter.Height = this.Height;
            filter.Width = this.Width;
            filter.Background = Design.Color.FgBlue;
            filter.CornerRadius = new CornerRadius(30) ;
            filter.BorderBrush = new SolidColorBrush(Colors.White);
            filter.BorderThickness = Thickness.Parse("1");
            filter.Margin = new Thickness(15, 0, 0, 0);
            filter.SelectedItem = "all";
            selectedItem = "all";
            // Handle the SelectionChanged event of the ComboBox
            filter.SelectionChanged += (sender, args) =>
            {
                if (args.Source is ComboBox cb)
                {
                    if (cb.SelectedItem != null)
                    {
                        selectedItem = cb.SelectedItem.ToString();
                    }
                }
            };
        }

    }

}
