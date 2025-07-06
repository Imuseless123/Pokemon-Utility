using System;
using System.Collections.Generic;

namespace Pokemon_Utility.Models.Entity;

public partial class PokemonAbility
{
    public int? PokemonId { get; set; }

    public string? AbilityName { get; set; }

    public virtual Pokemon? Pokemon { get; set; }
}
