using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EF_BeaversLife.Queries;

public class DeleteMe1
{
    private readonly AnimalContext _context;
    private List<Beaver> _contextBeavers;

    /// <summary>
    /// </summary>
    public void TestContextField()
    {
        DbSet<Animal> animals = _context.Animals;
        Console.ForegroundColor = ConsoleColor.Magenta;

        animals.First().Clubs.Add(null);
        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <summary>
    ///     Include is needed.
    /// </summary>
    public void UseInverseProperties()
    {
        using var context = new AnimalContext();
        var       persons = context.Persons;

        Console.ForegroundColor = ConsoleColor.Magenta;

        foreach (var person in persons)
        {
            Console.WriteLine(person);
            foreach (var animalLoved in person.AnimalsLoved)
            {
                Console.Write("\t");
                Console.WriteLine(animalLoved);
            }

            foreach (var animalHated in person.AnimalsHated)
            {
                Console.Write("\t");
                Console.Write("\t");
                Console.WriteLine(animalHated);
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <summary>
    /// Include is needed.
    /// </summary>
    public void DeleteMe2()
    {
        using var context = new AnimalContext();

        foreach (var elf in context.Elves)
        {
            Console.WriteLine(elf);

            var person = elf.Deer.LovedBy;

            for (var i = elf.Deer.Job.JobDrawbacks.Count - 1; i >= 0; i--)
            {
                var drawback = elf.Deer.Job.JobDrawbacks.ToArray()[i].Drawback;
                Console.Write("\t");
                Console.WriteLine(drawback);
            }
        }

        Console.ForegroundColor = ConsoleColor.Magenta;


        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <summary>
    /// 
    /// </summary>
    public void DeleteMe3()
    {
        using var context = new AnimalContext();

        Console.ForegroundColor = ConsoleColor.Magenta;

        foreach (var food in context.Food)
        {
            Console.WriteLine(food);

            foreach (var club in food.Animal.Clubs)
            {
            }

            foreach (var drawback in food.Drawbacks)
            {
                var consequence = drawback.Consequence;
                var drawback1   = drawback.JobDrawbacks.First().Job;
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <summary>
    /// Include is needed.
    /// </summary>
    public void DeleteMe4()
    {
        using var context = new AnimalContext();

        var beavers = context.Set<Beaver>();

        Console.ForegroundColor = ConsoleColor.Magenta;
        foreach (var beaver in beavers)
        {
            Console.WriteLine(beaver);

            if (beaver.Clubs != null)
            {
                foreach (var club in beaver.Clubs)
                {
                    Console.Write("\t");
                    Console.WriteLine(club);
                }
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
    }

    public void DeleteMe5()
    {
        // I'm bit confused today.
        using var context = new AnimalContext();

        var blah = context.Beavers.Include(x => x.Clubs).Where(beaver => beaver.Name != string.Empty).Select(w => new BeaverDTO
        {
            Test = new TestDTO
            {
                Name = w.Clubs.OrderByDescending(t => t.Title).FirstOrDefault().Title
            }
        });



        //var beavers = context.Beavers.Where(beaver => beaver.Name == "aaa").OrderByDescending(x => x.Id).FirstOrDefault().ToList();

        Console.ForegroundColor = ConsoleColor.Magenta;


        Console.WriteLine(blah.FirstOrDefault().Test.Name);

        Console.ForegroundColor = ConsoleColor.White;
    }

    public void DeleteMe6()
    {
        using var context = new AnimalContext();

        DbSet<Beaver> contextBeavers = context.Beavers;
        
        Beaver first;
        switch (contextBeavers.Any())
        {
            case false:
                {
                    if (!contextBeavers.Any())
                    {
                        first = contextBeavers.
                        first.Clubs = null;
                    }

                    break;
                }
            default:
                {
                    first = contextBeavers.First();
                    var beaver = first;
                    Console.WriteLine(beaver);
                    break;
                }
        }

        List<Club> clubs = first.Clubs;


        Console.ForegroundColor = ConsoleColor.Magenta;

        Console.WriteLine(beavers);

        Console.ForegroundColor = ConsoleColor.White;
    }

    private static DbSet<Beaver> ContextBeavers(DbSet<Beaver> contextBeavers)
    {
        return contextBeavers;
    }
}

public class TestDTO
{
    public string Name { get; set; }
}

public class BeaverDTO
{
    public TestDTO Test { get; set; }
}
