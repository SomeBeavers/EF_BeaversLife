using System;
using System.Linq;

namespace FrameworkLib_Common.Model_Renamed;

public class Consequence
{
    public string Name { get; set; } = null!;

    public override string ToString()
    {
        return $"Consequence : Name = {Name}";
    }
}
