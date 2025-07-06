using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using System;
using System.Linq;
using System.Reflection.Metadata;
using Pokemon_Utility.Controllers;

namespace Pokemon_Utility.Views.Browsing
{
    public class SortingButton : Panel
    {
        private SortingButtonController sortingButtonController;
        private Button sorter;
        private string content;

        public string Content
        {
            get { return content; }
        }

        // Constructor
        public SortingButton()
        {
            //change the SortingButton class properties
            this.Height = 60;
            this.Width = 150;

            sorter = new Button();
            sorter.FontSize = 20;
            //set the sorter as the children of the SortingButton class
            this.Children.Add(sorter);

            //change the sorter properties
            content = "Sort";
            sorter.Content = content;
            sorter.VerticalContentAlignment = VerticalAlignment.Center;
            sorter.HorizontalContentAlignment = HorizontalAlignment.Center;
            sorter.VerticalAlignment = VerticalAlignment.Center;
            sorter.Height = this.Height;
            sorter.Width = this.Width;
            sorter.CornerRadius = new CornerRadius(30);
            sorter.Foreground = new SolidColorBrush(Colors.White);
            sorter.Background = Design.Color.FgBlue;
            sorter.BorderBrush = new SolidColorBrush(Colors.White);
            sorter.BorderThickness = new Thickness(1);

            // Subscribe to the button click event
            sorter.Click += ClickHandler;
        }

        private bool sortById = true;

        public void ClickHandler(object sender, RoutedEventArgs args)
        {
            if (sender is Button)
            {
                sortById = !sortById;
                if (sortById == false)
                {
                    content = "Sort by: Name";
                    sorter.Content = content;
                }
                else
                {
                    content = "Sort by: ID";
                    sorter.Content = content;
                }
            }
        }

    }
}