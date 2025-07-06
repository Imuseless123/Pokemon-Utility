using System.Linq;
using System.Threading.Tasks;
using Pokemon_Utility.Models.Context;

namespace Pokemon_Utility.Controllers;

public class PokemonInfoTeam
{
    public int Id;
    public string Name;
    public string Type1;
    public string? Type2 = null;
    public int MovesetId;

    public PokemonInfoTeam(int id, int movesetId)
    {
        this.Id = id;
        this.MovesetId = movesetId;
        MainContext.Query(
            onReceive: context =>
            {
                Name = context.Pokemons.Find(id).Name;
                var types = context.PokemonTypes.Where(s => s.PokemonId == id).ToList();
                Type1 = types[0].Name;
                if (types.Count >1)
                {
                    Type2 = types[1].Name;
                }
            },
            onFailure: () => { }
        );
    }

    
}