using System;
using System.Linq;

using FrameworkLib_Common.Model_Renamed.NewFolder;

namespace FrameworkLib_Common.Model_Renamed;

//[Table("Beaver")]
public class Beaver : Animal
{
    [Required]
    public FluffinessEnum Fluffiness { get; set; }

    public int Size { get; set; }

    public override string ToString()
    {
        return @$"{base.ToString()} Beaver: Fluffiness = {Fluffiness} Size = {Size}";
    }
}

public enum FluffinessEnum
{
    NotFluffy,
    Fluffy,
    VeryFluffy
}
