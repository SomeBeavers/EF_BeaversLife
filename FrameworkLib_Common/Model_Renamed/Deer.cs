using System;
using System.Linq;

using FrameworkLib_Common.Model_Renamed.NewFolder;

namespace FrameworkLib_Common.Model_Renamed;

//[Table("Deer")]
public class Deer : Animal
{
    public bool Horns { get; set; }

    public override string ToString()
    {
        return @$"{base.ToString()} Deer : Horns = {this.Horns}";
    }
}
