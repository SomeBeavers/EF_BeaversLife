namespace EF_BeaversLife.Queries;

public class UseOwnedProperty
{
    public void OwnedViaFluentAPI()
    {
        using var context = new AnimalContext();

        var drawbacks = context.Drawbacks;

        Console.ForegroundColor = ConsoleColor.Magenta;

        foreach (var drawback in drawbacks)
        {
            Console.WriteLine(drawback.Consequence);
        }

        Console.ForegroundColor = ConsoleColor.White;
    }
}