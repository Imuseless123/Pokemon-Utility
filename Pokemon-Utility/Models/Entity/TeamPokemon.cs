using System;
using System.Collections.Generic;

namespace Pokemon_Utility.Models.Entity;

public partial class TeamPokemon
{
    public int? TeamId { get; set; }

    public int? PokemonId { get; set; }

    public int MovesetId { get; set; }

    public virtual Pokemon? Pokemon { get; set; }

    public virtual Team? Team { get; set; }
}
