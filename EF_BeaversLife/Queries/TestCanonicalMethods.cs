using System;
using System.Collections.Generic;
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
        var t = animals.Where(a => Math.Truncate(((decimal)a.Age)) > 10).ToList();
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
        Console.WriteLine(animals.Where(a => a.Clubs.Count > 5).Cast<string>());
    }
}

