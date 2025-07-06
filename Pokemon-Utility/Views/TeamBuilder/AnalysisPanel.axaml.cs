using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Microsoft.IdentityModel.Tokens;
using Pokemon_Utility.Controllers;

namespace Pokemon_Utility.Views.TeamBuilder;

public partial class AnalysisPanel : Panel
{
    private AnalysisPanelController analysisPanelController;

public AnalysisPanel(List<PokemonInfoTeam> pokemonList)
{
    analysisPanelController = new AnalysisPanelController(pokemonList);
        InitializeComponent();
        roundCornerBorder.Background = Design.Color.FgLightBlue;
        
        for (int i = 0; i < analysisPanelController.Coefficientlist.Count; i++)
        {
            //TO-DO
            if (analysisPanelController.Coefficientlist[i]!= 0)
            {
                anaStackPanel.Children.Add( new TypeChartBar(analysisPanelController.TypeList[i],analysisPanelController.Coefficientlist[i])); 
            }
        }
    }



}