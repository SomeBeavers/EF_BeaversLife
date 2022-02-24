using System;
using System.Linq;

using FrameworkLib_Common.Model_Renamed.NewFolder;

namespace FrameworkLib_Common.Model_Renamed;

public class Person
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [InverseProperty("LovedBy")]
    public virtual List<Animal>? AnimalsLoved { get; set; }

    [InverseProperty("HatedBy")]
    public virtual List<Animal>? AnimalsHated { get; set; }

    public override string ToString()
    {
        return $"Person : Id = {Id} Name = {Name}";
    }
}
