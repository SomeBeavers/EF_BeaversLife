namespace MSSQL_Core_App.Queries;

public class DbContextVariations
{
    /// <summary>
    ///     Include is needed.
    /// </summary>
    /// <param name="context"><see cref="DbContext"/> as parameter.</param>
    public void DbContextAsParameter(AnimalContext context)
    {
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
}