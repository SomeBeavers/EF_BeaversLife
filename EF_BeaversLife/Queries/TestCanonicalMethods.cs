using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace EF_BeaversLife.Queries;
public class TestCanonicalMethods
{
    [DbFunction("CustomDBFunction")]
    public static bool CustomDbFunction(int number) => throw new InvalidOperationException();

    public static bool NormalFunction() => throw new InvalidOperationException();

    public static void DbFunctionsUse()
    {
        using var context = new AnimalContext();
        var animals = context.Animals;

        var entities = animals.Where(entity => AnimalContext.Foo(entity.Age) > 10).ToList();

        foreach (var animal in animals.Where(a => a.Clubs.Select((club, i) => club.Id >= i).Any() ||
                                                  CustomDbFunction(a.Age) ||
                                                  Functions.Function() ||
                                                  AnimalContext.DbFunction(a.Age).Length > 0 ||
                                                  NormalFunction() ||
                                                  EF.Functions.IsNumeric("")))
        {
            Console.WriteLine(animal.Name);
        }

        foreach (var animal in animals.Include(animal => animal.Food))
        {
            Console.WriteLine(EF.Functions.IsNumeric(animal.Name));
        }
        
    }

    public static void Method()
    {
        using var context = new AnimalContext();
        var animals = context.Animals;
        var tmp = animals.Where(a => a.Id == new Random().Next()).ToList();
        Console.WriteLine(animals.Where((a,i) => a.Age >= i));
        Console.WriteLine(animals.OrderBy(a => a.Age, Comparer<int>.Default).First().Age);
        Console.WriteLine(animals.OrderBy(a => a.Age));
        foreach (var animal in animals.SelectMany(a => a.Clubs.FindAll(c => c.Animals.Count > c.Id)))
        {
            Console.WriteLine(animal);
        }

        Console.WriteLine(animals.Distinct());
        Console.WriteLine(animals.Average(a => a.Age));
        Console.WriteLine(animals.Count(a => a.Clubs.Count > 5));
        Console.WriteLine(animals.Count(a => a.Clubs.Count(c => c.Locations.Count > 3) > 3));
        Console.WriteLine(animals.Where(a => a.Clubs.Count > 5).Cast<string>());
        foreach (var str in animals.Select(a => a.Name.Substring(0, 1)))
        {
            Console.WriteLine(str);
        }
        
        var temp = animals.Zip(animals.Select(a => a.Age > 5)).ToList();
        var elementAt = animals.ElementAt(5);
        var append = animals.Append(new Animal());
        var reverse = animals.Reverse().ToList();
        var chunk = animals.Chunk(5).ToList();
        
    }

    public static void MathMethods()
    {
        using var context = new AnimalContext();
        var animals = context.Animals;

        //supported
        Console.WriteLine(animals.Where(a => Math.Log10(a.Age) > 10).ToList());
        Console.WriteLine(animals.Where(a => a.Age == 1 && Math.Acos(a.Age) > 10).ToList());
        Console.WriteLine(animals.Where(a => a.Age == 1 && Math.Asin(a.Age) > 10).ToList());
        Console.WriteLine(animals.Where(a => a.Age == 1 && Math.Atan(a.Age) > 10).ToList());
        Console.WriteLine(animals.Where(a => a.Age == 1 && Math.Atan2(a.Age, a.Id) > 10).ToList());
        Console.WriteLine(animals.Where(a => Math.Cos(a.Age) > 10).ToList());
        Console.WriteLine(animals.Where(a => Math.Exp(a.Age) > 10).ToList());
        Console.WriteLine(animals.Where(a => Math.Log(a.Age) > 10).ToList());
        Console.WriteLine(animals.Where(a => Math.Log10(a.Age) > 10).ToList());
        Console.WriteLine(animals.Where(a => Math.Sign(a.Age).Equals(0)).ToList());
        Console.WriteLine(animals.Where(a => Math.Sin(a.Age) > 10).ToList());
        Console.WriteLine(animals.Where(a => Math.Sqrt(a.Age) > 10).ToList());
        Console.WriteLine(animals.Where(a => Math.Tan(a.Age) > 10).ToList());
        Console.WriteLine(animals.Where(a => Math.Truncate(Convert.ToDecimal(a.Age)) > 10).ToList());
        Console.WriteLine(animals.Where(a => Math.Pow(a.Age, a.Id) > 10).ToList());
        Console.WriteLine(animals.Where(a => Math.Abs(a.Age) > 10).ToList());
        Console.WriteLine(animals.Where(a => Math.Round(Convert.ToDouble(a.Age)) > 10).ToList());
        Console.WriteLine(animals.Where(a => Math.Ceiling(Convert.ToDecimal(a.Age)) > 10).ToList());
        Console.WriteLine(animals.Where(a => Math.Floor(Convert.ToDecimal(a.Age)) > 10).ToList());
        


        //not supported

        //Console.WriteLine(animals.Where(a => a.Age == 1 && Math.Acosh(a.Age) > 10).ToList()); //-
        //Console.WriteLine(animals.Where(a => a.Age == 1 && Math.Asinh(a.Age) > 10).ToList()); //-
        //Console.WriteLine(animals.Where(a => a.Age == 1 && Math.Atanh(a.Age) > 10).ToList());
        //Console.WriteLine(animals.Where(a => Math.BigMul(a.Age, a.Id) > 10).ToList());
        //Console.WriteLine(animals.Where(a => Math.BitDecrement(a.Age) > 10).ToList());
        //Console.WriteLine(animals.Where(a => Math.BitIncrement(a.Age) > 10).ToList());
        //Console.WriteLine(animals.Where(a => Math.Cbrt(a.Age) > 10).ToList());
        //Console.WriteLine(animals.Where(a => Math.Clamp(a.Age, Double.MinValue, Double.MaxValue) > 10).ToList());
        //Console.WriteLine(animals.Where(a => Math.CopySign(a.Age, Double.MinValue) > 10).ToList());
        //Console.WriteLine(animals.Where(a => Math.Cosh(a.Age) > 10).ToList());
        //int t;
        //Console.WriteLine(animals.Where(a => Math.DivRem(a.Age, a.Id, out t) > 10).ToList());
        //Console.WriteLine(animals.Where(a => Math.FusedMultiplyAdd(a.Age, a.Id, a.Age) > 10).ToList());
        //Console.WriteLine(animals.Where(a => Math.IEEERemainder(a.Age, a.Id) > 10).ToList());
        //Console.WriteLine(animals.Where(a => Math.ILogB(a.Age) > 10).ToList());
        //Console.WriteLine(animals.Where(a => Math.Log2(a.Age) > 10).ToList());
        //Console.WriteLine(animals.Where(a => Math.Max(a.Age, a.Id) > 10).ToList());
        //Console.WriteLine(animals.Where(a => Math.MaxMagnitude(a.Age, a.Id) > 10).ToList());
        //Console.WriteLine(animals.Where(a => Math.Min(a.Age, a.Id) > 10).ToList());
        //Console.WriteLine(animals.Where(a => Math.MinMagnitude(a.Age, a.Id) > 10).ToList());
        //Console.WriteLine(animals.Where(a => Math.ReciprocalEstimate(a.Age) > 10).ToList());
        //Console.WriteLine(animals.Where(a => Math.ReciprocalSqrtEstimate(a.Age) > 10).ToList());
        //Console.WriteLine(animals.Where(a => Math.ScaleB(a.Age, a.Id) > 10).ToList());
        //Console.WriteLine(animals.Where(a => Math.Sinh(a.Age) > 10).ToList());
        //Console.WriteLine(animals.Where(a => Math.SinCos(a.Age).Cos > 5).ToList());
        //Console.WriteLine(animals.Where(a => Math.Tanh(a.Age) > 10).ToList());
    }

    public static void StringMethods()
    {
        using var context = new AnimalContext();
        var animals = context.Animals;

        //supported
        
        Console.WriteLine(animals.Where(a => a.Name.EndsWith("f")).ToList());
        Console.WriteLine(animals.Where(a => a.Name.StartsWith("f").Equals(true)).ToList());
        Console.WriteLine(animals.Where(a => a.Name.CompareTo("dsfds").Equals("df")).ToList());
        Console.WriteLine(animals.Where(a => a.Name.Clone().Equals("")));
        Console.WriteLine(animals.Where(a => a.Name.Contains("d")).ToList());
        Console.WriteLine(animals.Where(a => a.Name.Equals("tes")).ToList());
        Console.WriteLine(animals.Where(a => String.IsNullOrEmpty(a.Name).Equals("")).ToList());
        Console.WriteLine(animals.Where(a => a.Name.IndexOf("4").Equals("")).ToList());
        Console.WriteLine(animals.Where(a => String.IsNullOrWhiteSpace(a.Name).Equals("")).ToList());
        Console.WriteLine(animals.Where(a => a.Name.Length == 4).ToList());
        Console.WriteLine(animals.Where(a => a.Name.ToLower().Equals("df")).ToList());
        Console.WriteLine(animals.Where(a => a.Name.ToUpper().Equals("df")).ToList());
        Console.WriteLine(animals.Where(a => a.Name.Substring(4).Equals("df")).ToList());
        Console.WriteLine(animals.Where(a => a.Name.Substring(4,5).Equals("df")).ToList());
        Console.WriteLine(animals.Where(a => a.Name.Trim().Equals("df")).ToList());
        Console.WriteLine(animals.Where(a => a.Name.TrimEnd().Equals("df")).ToList());
        Console.WriteLine(animals.Where(a => a.Name.TrimStart().Equals("df")).ToList());
        Console.WriteLine(animals.Where(a => String.Compare(a.Name, a.Age.ToString()) == 0).ToList());
        Console.WriteLine(animals.Where(a => a.Name.Replace("y", "y").Equals("")).ToList());
        Console.WriteLine(animals.Where(a => String.Concat('t', 'd').Equals("")).ToList());


        //not supported
        Console.WriteLine(animals.Where(a => a.Name.EndsWith('f')).ToList());
        Console.WriteLine(animals.Where(a => a.Name.StartsWith('f').Equals(true)).ToList());
        Console.WriteLine(animals.Where(a => a.Name.Contains('y')).ToList());
        Console.WriteLine(animals.Where(a => a.Name.Contains("s", StringComparison.CurrentCulture)).ToList());
        Console.WriteLine(animals.Where(a => a.Name.Contains('f', StringComparison.CurrentCulture)).ToList());
        Console.WriteLine(animals.Where(a => String.Compare(a.Name, 5, a.Age.ToString(), 4, 5, true) == 0).ToList());
        Console.WriteLine(animals.Where(a => String.Compare(a.Name, "r", StringComparison.Ordinal) > 3).ToList());
        Console.WriteLine(animals.Where(a => String.Concat(a.Name).Equals("")).ToList());
        Console.WriteLine(animals.Where(a => String.Concat(a.Age.ToString(), 'd').Equals("")).ToList());
        Console.WriteLine(animals.Where(a => String.Copy(a.Name).Equals("")).ToList());
        Console.WriteLine(animals.Where(a => String.Format(a.Name).Equals("")).ToList());
        Console.WriteLine(animals.Where(a => a.Name.IndexOf("4", StringComparison.Ordinal).Equals("")).ToList());
        Console.WriteLine(animals.Where(a => a.Name.Insert(4, "g").Equals("")).ToList());
        Console.WriteLine(animals.Where(a => String.Intern(a.Name).Equals("")).ToList());
        Console.WriteLine(animals.Where(a => a.Name.IsNormalized() == true).ToList());
        Console.WriteLine(animals.Where(a => a.Name.LastIndexOf('t').Equals(4)).ToList());
        Console.WriteLine(animals.Where(a => a.Name.LastIndexOf("t").Equals(4)).ToList());
        Console.WriteLine(animals.Where(a => a.Name.Normalize().Equals("")).ToList());
        Console.WriteLine(animals.Where(a => a.Name.Replace('f', 't').Equals("")).ToList());
        Console.WriteLine(animals.Where(a => a.Name.Replace("t", "r", true, CultureInfo.CurrentCulture).Equals("")).ToList());
        Console.WriteLine(animals.Where(a => a.Name.Remove(5, 5).Equals("")).ToList());
        Console.WriteLine(animals.Where(a => a.Name.Remove(4).Equals("")).ToList());
        Console.WriteLine(animals.Where(a => a.Name.ToLower(CultureInfo.CurrentCulture).Equals("df")).ToList());
        Console.WriteLine(animals.Where(a => a.Name.ToLowerInvariant().Equals("df")).ToList());
        Console.WriteLine(animals.Where(a => a.Name.ToUpperInvariant().Equals("df")).ToList());


    }

}

