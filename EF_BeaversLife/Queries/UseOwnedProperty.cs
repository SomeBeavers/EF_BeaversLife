using B;

namespace EF_BeaversLife.Queries;

public class UseOwnedProperty
{
    /// <summary>
    /// drawback.OwnsOne(d => d.Consequence,
    /// Include is not needed.
    /// </summary>
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