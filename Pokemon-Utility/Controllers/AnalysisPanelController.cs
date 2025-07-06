using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;

namespace Pokemon_Utility.Controllers;

public class AnalysisPanelController
{
    private List<string> teamTypeList = new List<string>();

    public List<string> TypeList = new List<string>
    {
        "normal", "fire", "water", "electric", "grass", "ice", "fighting", "poison", "ground", "flying", "psychic",
        "bug", "rock", "ghost", "dragon", "dark", "steel", "fairy"
    };
    private List<int> teamTypeNumList = new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public List<int> Coefficientlist = new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    public AnalysisPanelController(List<PokemonInfoTeam> pokemonList)
    {
        foreach (var pokemon in pokemonList)
        {
            teamTypeList.Add(pokemon.Type1);
            if (!pokemon.Type2.IsNullOrEmpty())
            {
                teamTypeList.Add(pokemon.Type2);

            }
        }
        foreach (var type in teamTypeList)
        {
            teamTypeNumList[TypeList.IndexOf(type)]++;
            setCoeffiecent(type);
        }
    }

    private void setCoeffiecent(string type)
    {
        switch (type)
        {
            case "normal":
            {
                Coefficientlist[TypeList.IndexOf("fighting")]--;
                Coefficientlist[TypeList.IndexOf("ghost")]++;
            }
                break;
            case "fire":
            {
                Coefficientlist[TypeList.IndexOf("fire")]++;
                Coefficientlist[TypeList.IndexOf("water")]--;
                Coefficientlist[TypeList.IndexOf("grass")]++;
                Coefficientlist[TypeList.IndexOf("ice")]++;
                Coefficientlist[TypeList.IndexOf("ground")]--;
                Coefficientlist[TypeList.IndexOf("steel")]++;
                Coefficientlist[TypeList.IndexOf("fairy")]++;
            }
                break;
            case "water":
            {
                Coefficientlist[TypeList.IndexOf("fire")]++;
                Coefficientlist[TypeList.IndexOf("water")]++;
                Coefficientlist[TypeList.IndexOf("electric")]--;
                Coefficientlist[TypeList.IndexOf("grass")]--;
                Coefficientlist[TypeList.IndexOf("ice")]++;
                Coefficientlist[TypeList.IndexOf("steel")]++;
            }
                break;
            case "electric":
            {
                Coefficientlist[TypeList.IndexOf("electric")]++;
                Coefficientlist[TypeList.IndexOf("ground")]--;
                Coefficientlist[TypeList.IndexOf("flying")]++;
                Coefficientlist[TypeList.IndexOf("steel")]--;

            }
                break;
            case "grass":
            {
                Coefficientlist[TypeList.IndexOf("fire")]--;
                Coefficientlist[TypeList.IndexOf("water")]++;
                Coefficientlist[TypeList.IndexOf("electric")]++;
                Coefficientlist[TypeList.IndexOf("grass")]++;
                Coefficientlist[TypeList.IndexOf("ice")]--;
                Coefficientlist[TypeList.IndexOf("poison")]--;
                Coefficientlist[TypeList.IndexOf("ground")]++;
                Coefficientlist[TypeList.IndexOf("flying")]--;
                Coefficientlist[TypeList.IndexOf("bug")]--;
                
            }
                break;
            case "ice":
            {
                Coefficientlist[TypeList.IndexOf("fire")]--;
                Coefficientlist[TypeList.IndexOf("ice")]++;
                Coefficientlist[TypeList.IndexOf("fighting")]--;
                Coefficientlist[TypeList.IndexOf("rock")]--;
                Coefficientlist[TypeList.IndexOf("steel")]--;
                
            }
                break;
            case "fighting":
            {
                Coefficientlist[TypeList.IndexOf("flying")]--;
                Coefficientlist[TypeList.IndexOf("psychic")]--;
                Coefficientlist[TypeList.IndexOf("rock")]++;
                Coefficientlist[TypeList.IndexOf("bug")]++;
                Coefficientlist[TypeList.IndexOf("dark")]++;
                Coefficientlist[TypeList.IndexOf("fairy")]--;

            }
                break;
            case "poison":
            {
                Coefficientlist[TypeList.IndexOf("grass")]++;
                Coefficientlist[TypeList.IndexOf("fighting")]++;
                Coefficientlist[TypeList.IndexOf("poison")]++;
                Coefficientlist[TypeList.IndexOf("ground")]--;
                Coefficientlist[TypeList.IndexOf("psychic")]--;
                Coefficientlist[TypeList.IndexOf("bug")]++;
                Coefficientlist[TypeList.IndexOf("fairy")]++;

            }
                break;
            case "ground":
            {
                Coefficientlist[TypeList.IndexOf("water")]--;
                Coefficientlist[TypeList.IndexOf("electric")]++;
                Coefficientlist[TypeList.IndexOf("grass")]--;
                Coefficientlist[TypeList.IndexOf("ice")]--;
                Coefficientlist[TypeList.IndexOf("poison")]++;
                Coefficientlist[TypeList.IndexOf("rock")]++;

            }
                break;
            case "flying":
            {
                Coefficientlist[TypeList.IndexOf("electric")]--;
                Coefficientlist[TypeList.IndexOf("grass")]++;
                Coefficientlist[TypeList.IndexOf("ice")]--;
                Coefficientlist[TypeList.IndexOf("fighting")]++;
                Coefficientlist[TypeList.IndexOf("ground")]++;
                Coefficientlist[TypeList.IndexOf("bug")]++;
                Coefficientlist[TypeList.IndexOf("rock")]--;

            }
                break;
            case "psychic":
            {
                Coefficientlist[TypeList.IndexOf("fighting")]++;
                Coefficientlist[TypeList.IndexOf("psychic")]++;
                Coefficientlist[TypeList.IndexOf("bug")]--;
                Coefficientlist[TypeList.IndexOf("ghost")]--;
                Coefficientlist[TypeList.IndexOf("dark")]--;

            }
                break;
            case "bug":
            {
                Coefficientlist[TypeList.IndexOf("fire")]--;
                Coefficientlist[TypeList.IndexOf("grass")]++;
                Coefficientlist[TypeList.IndexOf("fighting")]++;
                Coefficientlist[TypeList.IndexOf("ground")]++;
                Coefficientlist[TypeList.IndexOf("flying")]--;
                Coefficientlist[TypeList.IndexOf("rock")]--;

            }
                break;
            case "rock":
            {
                Coefficientlist[TypeList.IndexOf("normal")]++;
                Coefficientlist[TypeList.IndexOf("fire")]++;
                Coefficientlist[TypeList.IndexOf("water")]--;
                Coefficientlist[TypeList.IndexOf("grass")]--;
                Coefficientlist[TypeList.IndexOf("fighting")]--;
                Coefficientlist[TypeList.IndexOf("poison")]++;
                Coefficientlist[TypeList.IndexOf("flying")]--;
                Coefficientlist[TypeList.IndexOf("steel")]--;

            }
                break;
            case "ghost":
            {
                Coefficientlist[TypeList.IndexOf("normal")]++;
                Coefficientlist[TypeList.IndexOf("fighting")]++;
                Coefficientlist[TypeList.IndexOf("poison")]++;
                Coefficientlist[TypeList.IndexOf("bug")]++;
                Coefficientlist[TypeList.IndexOf("ghost")]--;
                Coefficientlist[TypeList.IndexOf("dark")]--;
                
            }
                break;
            case "dragon":
            {
                Coefficientlist[TypeList.IndexOf("fire")]++;
                Coefficientlist[TypeList.IndexOf("water")]++;
                Coefficientlist[TypeList.IndexOf("electric")]++;
                Coefficientlist[TypeList.IndexOf("grass")]++;
                Coefficientlist[TypeList.IndexOf("ice")]--;
                Coefficientlist[TypeList.IndexOf("dragon")]--;
                Coefficientlist[TypeList.IndexOf("fairy")]--;

            }
                break;
            case "dark":
            {
                Coefficientlist[TypeList.IndexOf("fighting")]--;
                Coefficientlist[TypeList.IndexOf("psychic")]++;
                Coefficientlist[TypeList.IndexOf("bug")]++;
                Coefficientlist[TypeList.IndexOf("ghost")]++;
                Coefficientlist[TypeList.IndexOf("dark")]++;
                Coefficientlist[TypeList.IndexOf("fairy")]--;

            }
                break;
            case "steel":
            {
                Coefficientlist[TypeList.IndexOf("steel")]++;
                Coefficientlist[TypeList.IndexOf("fire")]--;
                Coefficientlist[TypeList.IndexOf("grass")]++;
                Coefficientlist[TypeList.IndexOf("ice")]++;
                Coefficientlist[TypeList.IndexOf("fighting")]--;
                Coefficientlist[TypeList.IndexOf("poison")]++;
                Coefficientlist[TypeList.IndexOf("ground")]--;
                Coefficientlist[TypeList.IndexOf("flying")]++;
                Coefficientlist[TypeList.IndexOf("psychic")]++;
                Coefficientlist[TypeList.IndexOf("bug")]++;
                Coefficientlist[TypeList.IndexOf("rock")]++;
                Coefficientlist[TypeList.IndexOf("dragon")]++;
                Coefficientlist[TypeList.IndexOf("steel")]++;
                Coefficientlist[TypeList.IndexOf("fairy")]++;

            }
                break;
            case "fairy":
            {
                Coefficientlist[TypeList.IndexOf("fighting")]++;
                Coefficientlist[TypeList.IndexOf("poison")]--;
                Coefficientlist[TypeList.IndexOf("bug")]++;
                Coefficientlist[TypeList.IndexOf("dragon")]++;
                Coefficientlist[TypeList.IndexOf("dark")]++;
                Coefficientlist[TypeList.IndexOf("steel")]--;

            }
                break;
        }
    }
}