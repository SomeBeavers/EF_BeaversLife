using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_BeaversLife.Queries;
public class TestCanonicalMethods
{
    [DbFunction("CustomDBFunction")]
    public static bool CustomDbFunction(int number) => throw new InvalidOperationException();

    public static bool NormalFunction() => throw new InvalidOperationException();

    public static int Foo(int n, int x)
    {
        return n + x;
    }
    public static void Method()
    {
        using var context = new AnimalContext();
        var animals = context.Animals;

        foreach (var animal in animals.Where(a => a.Clubs.Select((club, i) => club.Id >= i).Any() ||
                                                  CustomDbFunction(a.Age) ||
                                                  Functions.Function() ||
                                                  AnimalContext.DbFunction().Length > 0 ||
                                                  NormalFunction()))
        {
            Console.WriteLine(animal.Name);
        }

        foreach (var animal in animals.Include(animal => animal.Food))
        {
            Console.WriteLine(EF.Functions.IsNumeric(animal.Name));
        }
        var t = animals.Where(a => Math.Pow(a.Age, 2) > 10).ToList();
        var tmp = animals.Where(a => a.Id == new Random().Next()).ToList();
        Console.WriteLine(animals.OrderBy(a => a.Age, Comparer<int>.Default).First().Age);
    }
}

