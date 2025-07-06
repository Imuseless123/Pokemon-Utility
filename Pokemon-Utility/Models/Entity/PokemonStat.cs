using System;
using System.Collections.Generic;

namespace Pokemon_Utility.Models.Entity;

public partial class PokemonStat
{
    public int? PokemonId { get; set; }

    public string? Name { get; set; }

    public int? BaseStat { get; set; }

    public virtual Pokemon? Pokemon { get; set; }
}
