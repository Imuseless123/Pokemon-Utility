using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Pokemon_Utility.Controllers;
using Pokemon_Utility.Models.Context;

namespace Pokemon_Utility.Views.TeamBuilder;

public class TeamPage : Grid
{
    private TeamPageController teamPageController;
    public TeamPage()
    {
        // this.Children.Add(_teamPanel);
        // this.Children.Add(_analysisPanel);
        this.ColumnDefinitions = ColumnDefinitions.Parse("3*,2*");
        this.RowDefinitions = RowDefinitions.Parse("1*,160");
        // Grid.SetColumn(_teamPanel,0);
        // Grid.SetColumn(_analysisPanel,1);
    }

    public TeamPage(int teamID ) : this()
    {

        teamPageController = new TeamPageController(teamID);
        this.Children.Clear();
        Display();
        // this.Children.Add( new TeamPanel());
        // this.Children.Add(_analysisPanel);
        // Grid.SetColumn(_teamPanel,0);
        // Grid.SetColumn(_analysisPanel,1);

    }

    private void Display()
    {
        var teamPanel = new TeamPanel(teamPageController.PokemonList);
        this.Children.Add(teamPanel);
        Grid.SetColumn(teamPanel, 0);
        var teamAnalysis = new AnalysisPanel(teamPageController.PokemonList);
        this.Children.Add(teamAnalysis);
        Grid.SetColumn(teamAnalysis, 1);
        Grid.SetRowSpan(teamAnalysis, 2);
        var cRUDbutton = new CRUDButton(teamPageController.TeamID);
        this.Children.Add(cRUDbutton);
        Grid.SetColumn(cRUDbutton, 0);
        Grid.SetRow(cRUDbutton, 1);
    }
}