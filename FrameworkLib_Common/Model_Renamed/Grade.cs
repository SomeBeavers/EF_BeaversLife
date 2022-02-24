using System;
using System.Linq;

using FrameworkLib_Common.Model_Renamed.NewFolder;

namespace FrameworkLib_Common.Model_Renamed;

public class Grade
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public double? TheGrade { get; set; }

    public virtual Club Club { get; set; } = null!;
    public virtual Animal Animal { get; set; } = null!;

    public override string ToString()
    {
        return $"Grade : Id = {Id} Grade = {TheGrade}";
    }
}

public interface IGrade2
{
    int     Id       { get; set; }
    double? TheGrade { get; set; }
    Club    Club     { get; set; }
    Animal  Animal   { get; set; }
    string  ToString();
}

public class Grade2 : IGrade2
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public double? TheGrade { get; set; }

    public virtual Club Club { get; set; } = null!;
    public virtual Animal Animal { get; set; } = null!;

    public override string ToString()
    {
        return $"Grade : Id = {Id} Grade = {TheGrade}";
    }
}
