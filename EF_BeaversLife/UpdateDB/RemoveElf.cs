namespace MSSQL_Core_App.UpdateDB;
class RemoveElf
{
    public void RemoveElf1()
    {
        using var context = new AnimalContext();
        Elf elf = context.Elves.Include(elf => elf.Deer).First();
        Console.WriteLine(elf);
        var elfId = elf.Id;

        elf.Deer.Elves = null;

        context.SaveChanges();

        Elf elfAfterChanges = context.Elves.FirstOrDefault(elf => elf.Id == elfId);
        if (elfAfterChanges != null)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(elfAfterChanges);
        }
        else
        {
            Console.WriteLine($"Elf {elfId} is removed.");
        }
    }
}
