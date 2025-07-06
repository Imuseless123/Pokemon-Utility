using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;

namespace Pokemon_Utility.Views.TeamBuilder;

public partial class TypeChart : Panel
{
    public TypeChart()
    {
        InitializeComponent();
        border.Background = Design.Color.BgLightGray;
        foreach (var cell in typeGrid.Children.ToList())
        {
            if (cell is Panel)
            {
                continue;
            }
            if (cell is TextBlock textBox)
            {
                textBox.FontSize = 18;
                var cellTextBlock = new TextBlock
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                };
                var rowProperties= textBox.GetValue(Grid.RowProperty);
                var columnProperties= textBox.GetValue(Grid.ColumnProperty);
                Border cellBorder = new Border
                {
                    CornerRadius = new CornerRadius(10),
                    Child = cellTextBlock,
                };
                typeGrid.Children.Add(cellBorder);
                Grid.SetRow(cellBorder,rowProperties);
                Grid.SetColumn(cellBorder,columnProperties);
                switch (textBox.Text )
                {
                    case "2\u00d7" :
                        cellBorder.Background = Brushes.Green;
                        cellTextBlock.Foreground = Brushes.White;
                        cellTextBlock.Text = "2\u00d7";
                        break;
                    case "\u00bd\u00d7" :
                        cellBorder.Background = Brushes.DarkRed;
                        cellTextBlock.Foreground = Brushes.White;
                        cellTextBlock.Text = "\u00bd\u00d7";
                        break;
                    case "0\u00d7" :
                        cellBorder.Background = Brushes.DimGray;
                        cellTextBlock.Foreground = Brushes.White;
                        cellTextBlock.Text = "0\u00d7";
                        break;
                }
                
            }

            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.HorizontalAlignment = HorizontalAlignment.Center;
        }
    }
}