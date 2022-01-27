namespace EF_BeaversLife.Queries;

public class UseDisabledLazyLoading
{
    /// <summary>
    /// Include is needed.
    /// </summary>
    public void OneToOneRelation()
    {
        using var context = new AnimalContext();

        var food = context.Food;

        Console.ForegroundColor = ConsoleColor.Magenta;
        foreach (var f in food)
        {
            var animal = f.Animal;
            Console.WriteLine(animal);
        }

        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <summary>
    /// Include is NOT needed.
    /// </summary>
    public void AlreadyUsedProperty()
    {
        using var context = new AnimalContext();

        var animals = context.Animals.ToList();
        var food    = context.Food;

        Console.ForegroundColor = ConsoleColor.Magenta;
        foreach (var f in food)
        {
            Console.WriteLine(f);
            var animal = f.Animal;
            Console.Write("\t");
            Console.WriteLine(animal);
        }

        Console.ForegroundColor = ConsoleColor.White;
    }
}
