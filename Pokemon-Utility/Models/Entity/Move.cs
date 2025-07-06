using System;
using System.Collections.Generic;

namespace Pokemon_Utility.Models.Entity;

public partial class Move
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? Class { get; set; }

    public int? Power { get; set; }

    public int? Accuracy { get; set; }

    public int? Pp { get; set; }

    public int? Priority { get; set; }
}
