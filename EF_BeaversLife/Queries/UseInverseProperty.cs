namespace EF_BeaversLife.Queries;

public class UseInverseProperty
{
    /// <summary>
    ///     Include is needed.
    /// </summary>
    public void UseInverseProperty1()
    {
        using var context = new AnimalContext();
        var       persons = context.Persons;

        Console.ForegroundColor = ConsoleColor.Magenta;

        foreach (var person in persons.Include(person => person.AnimalsHated).Include(person => person.AnimalsLoved))
        {
            Console.WriteLine(person);
            foreach (var animalLoved in person.AnimalsLoved)
            {
                Console.Write("\t");
                Console.WriteLine(animalLoved);
            }

            NewFunction(person);
        }

        Console.ForegroundColor = ConsoleColor.White;

        
        
        
        
        
        
        
        
        
        
        
        void NewFunction(Person person)
        {
            foreach (var animalHated in person.AnimalsHated)
            {
                Console.Write("\t");
                Console.Write("\t");
                Console.WriteLine(animalHated);
            }
        }
    }
}
