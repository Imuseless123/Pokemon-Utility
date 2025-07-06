using System;
using System.Collections.Generic;

namespace Pokemon_Utility.Models.Entity;

public partial class Team
{
    public string? Name { get; set; }

    public string? Format { get; set; }

    public int Id { get; set; }

    public virtual ICollection<TeamPokemon> TeamPokemons { get; set; } = new List<TeamPokemon>();
}
