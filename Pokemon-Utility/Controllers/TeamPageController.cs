using System.Collections.Generic;
using System.Linq;
using Pokemon_Utility.Models.Context;

namespace Pokemon_Utility.Controllers;

public class TeamPageController
{
    public int TeamID;
    public List<PokemonInfoTeam> PokemonList = new List<PokemonInfoTeam>();

    public TeamPageController(int teamID)
    {
        this.TeamID = teamID;
        QueryForInfoTeam();
    }
    private void QueryForInfoTeam()
    {
        MainContext.Query(
            onReceive: context =>
            {
                var team = context.TeamPokemons.Where(s => s.TeamId == this.TeamID).ToList();
                foreach (var pokemon in team)
                {
                    if (pokemon.PokemonId != null)
                    {
                        PokemonList.Add( new PokemonInfoTeam((int)pokemon.PokemonId, pokemon.MovesetId));
                    }
                }
                
            },
            onFailure: () => { }
        );
    }
}