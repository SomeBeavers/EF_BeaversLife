using B;

namespace MSSQL_Core_App.UpdateDB;
class AddElf
{
    /// <summary>
    /// Include is needed for `deer.Elves`.
    /// </summary>
    public void AddElf1()
    {
        using var context = new AnimalContext();
        Deer deer = context.Deers
            // here
            .Include(deer => deer.Elves)
            .First(deer => deer.Elves.Count == 1);
        deer.Elves.Add(new Elf { Name = "Legolas" });

        context.SaveChanges();

        deer = context.Deers.First(deer => deer.Elves.Any(elf => elf.Name == "Legolas"));
        Console.WriteLine(deer);
    }


    /// <summary>
    /// Include is needed.
    /// </summary>
    public void ReplaceElvesCollection()
    {
        using var context = new AnimalContext();

        Deer deer = context.Deers
            //.Include(deer => deer.Elves)
            .First();

        Console.ForegroundColor = ConsoleColor.Magenta;

        //List<int> elfIds = new List<int>();
        //foreach (var elf in deer.Elves)
        //{
        //    elfIds.Add(elf.Id);
        //    Console.WriteLine(elf.Id);
        //}

        Console.ForegroundColor = ConsoleColor.White;

        deer.Elves = new List<Elf>()
        {
            new Elf{ Name = "Legolas" }
        };
        context.SaveChanges();


        //List<int> elfIds = new List<int>() { 1, 2 };
        //List<Elf> elves = context.Elves.Where(elf => elfIds.Contains(elf.Id)).ToList();

        //foreach (var elf in elves)
        //{
        //    Console.WriteLine(elf);
        //}

        deer = context.Deers.Include(item => item.Elves)
                      //.Include(deer => deer.Elves)
                      .First();

        foreach (var elf in deer.Elves)
        {
            Console.WriteLine(elf);
        }
    }
}
