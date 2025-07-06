using System;
using System.Collections.Generic;

namespace Pokemon_Utility.Models.Entity;

public partial class PokemonType
{
    public int? PokemonId { get; set; }

    public string? Name { get; set; }

    public int? Slot { get; set; }
}
