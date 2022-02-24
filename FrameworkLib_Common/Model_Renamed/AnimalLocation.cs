using System;
using System.Linq;

namespace FrameworkLib_Common.Model_Renamed;

// Table-valued functions
public class AnimalLocation
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;

    public override string ToString()
    {
        return $"AnimalLocation : Name = {Name} Address = {Address}";
    }
}
