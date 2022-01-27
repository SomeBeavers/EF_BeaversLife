namespace EF_BeaversLife_Framework.Queries;

public class DeleteMe
{
    /// <summary>
    /// Include is needed.
    /// </summary>
    public void DeleteMe2()
    {
        using var context = new AnimalContext();

        Console.ForegroundColor = ConsoleColor.Magenta;

        foreach (var deer in context.Deers)
        {
            Console.WriteLine(deer);

            var person = deer.LovedBy;

            for (var i = deer.Job.JobDrawbacks.Count - 1; i >= 0; i--)
            {
                var drawback = deer.Job.JobDrawbacks.ToArray()[i].Drawback;
                Console.Write("\t");
                Console.WriteLine(drawback);
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
    }
}
