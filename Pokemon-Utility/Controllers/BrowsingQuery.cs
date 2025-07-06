using System.Linq;
using Pokemon_Utility.Models.Context;

namespace Pokemon_Utility.Controllers
{
    public class BrowsingQuery
	{
        int nOfPokemonFound;

        public BrowsingQuery()
		{
            nOfPokemonFound = 0;
        }

        public int NOfPokemonFound
        {
            get { return nOfPokemonFound; }
            set { nOfPokemonFound = value; }
        }

        //this is the query when the user input the keyword(name) in the search bar
        public string[,] PokemonQuery_byName(string name, string filter = "all")
        {
            nOfPokemonFound = 0;
            string[] pokemonName = new string[nOfPokemonFound];
            string[] pokemonT1 = new string[nOfPokemonFound];
            string[] pokemonT2 = new string[nOfPokemonFound];
            int[] pokemonId = new int[nOfPokemonFound];
            //get the name, id, type of the pokemons found
            MainContext.Query(
                onReceive: async context =>
                {
                    var pokemonType1 = from t1 in context.PokemonTypes
                                  join t2 in context.Pokemons on t1.PokemonId equals t2.Id
                                  where t2.Name.Contains(name) && t1.Slot == 1
                                  select new
                                {
                                    Id=t2.Id,
                                    Name=t2.Name,
                                    Type=t1.Name
                                };
                    var pokemonType2 = from t1 in context.PokemonTypes
                                  join t2 in context.Pokemons on t1.PokemonId equals t2.Id
                                  where t2.Name.Contains(name) && t1.Slot == 2
                                  select new
                                  {
                                      Id = t2.Id,
                                      Type = t1.Name
                                  };
                    var pokemon = from t1 in pokemonType1
                                join t2 in pokemonType2 on t1.Id equals t2.Id into joinedEntities
                                from j in joinedEntities.DefaultIfEmpty()
                                where t1.Type == (filter == "all" ? t1.Type : filter) || j.Type == (filter == "all" ? j.Type : filter)
                                select new
                                {
                                    Id = t1.Id,
                                    Name = t1.Name,
                                    Type1 = t1.Type,
                                    Type2 = j.Type == null ? "null" : j.Type
                                  };

                    //var pokemon = query.ToList();
                    foreach (var entity in pokemon)
                    {
                        nOfPokemonFound++;
                    }

                    pokemonName = new string[nOfPokemonFound];
                    pokemonT1 = new string[nOfPokemonFound];
                    pokemonT2 = new string[nOfPokemonFound];
                    pokemonId = new int[nOfPokemonFound];

                    int index = 0;
                    foreach (var entity in pokemon)
                    {
                        pokemonName[index] = entity.Name;
                        pokemonId[index] = entity.Id;
                        pokemonT1[index] = entity.Type1;
                        pokemonT2[index] = entity.Type2;
                        index++;
                    }
                },
                onFailure: () => nOfPokemonFound = 0
            );

            //save the query infomation
            string[,] pokemonList = new string[nOfPokemonFound, 4];
            for(int i = 0; i < nOfPokemonFound; i++)
            {
                pokemonList[i, 0] = pokemonId[i].ToString();
                pokemonList[i, 1] = pokemonName[i];
                pokemonList[i, 2] = pokemonT1[i];
                pokemonList[i, 3] = pokemonT2[i];
            }

            return pokemonList;
        }
    }
}

