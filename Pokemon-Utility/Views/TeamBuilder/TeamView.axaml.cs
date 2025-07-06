using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Pokemon_Utility.Models.Context;
using Pokemon_Utility.Models.Entity;

namespace Pokemon_Utility.Views.TeamBuilder;

public partial class TeamView : Panel
{
    private TeamTopBar _teamTopBar = new TeamTopBar();
    private TeamPage _teamPage = new TeamPage();

    private List<Team> teamList = new List<Team>();

    public TeamView()
    {
        InitializeComponent();
        grid.Children.Add(_teamTopBar);
        grid.Children.Add(_teamPage);
        Grid.SetRow(_teamTopBar,0);
        Grid.SetRow(_teamPage,1);
        refreshButton.Click += (sender, args) =>
        {
            SetUp();
        };
    }

    public void SetUp()
    {
        grid.Children.Clear();
        QueryForTeam();
        // Load First team
        if (teamList.Count > 0)
        {
            _teamPage = new TeamPage(teamList[0].Id);
            grid.Children.Add(_teamPage);
            Grid.SetRow(_teamPage,1);
        }

        // _teamPage = new TeamPage();
        //
        // grid.Children.Add(_teamPage);
        //
        // Grid.SetRow(_teamPage,1);
        
        
    }
    private void QueryForTeam()
    {
        MainContext.Query(
            onReceive: context =>
            {
                teamList = context.Teams.ToList();
                List<string> teamName = new List<string>();
                foreach (var team in teamList)
                {
                    teamName.Add(team.Name);
                }
                _teamTopBar = new TeamTopBar( teamName);    
                grid.Children.Add(_teamTopBar) ;
                Grid.SetRow(_teamTopBar,0);
                (_teamTopBar.Children[0] as ListBox).SelectionChanged += OnSelect;
                
            },
            onFailure: () => { }
        );
    }
    private void OnSelect(object? sender, SelectionChangedEventArgs e)
    {
        grid.Children.Remove(_teamPage);
        _teamPage = new TeamPage(teamList[(sender as ListBox).SelectedIndex].Id);
        grid.Children.Add(_teamPage);
        Grid.SetRow(_teamPage,1);

    }

    
}