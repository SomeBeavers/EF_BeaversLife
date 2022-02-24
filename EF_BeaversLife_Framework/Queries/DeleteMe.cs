using FrameworkLib_Common.Model_Renamed;

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
            Console.Write("\t");

            var person = deer.HatedBy;

            Console.WriteLine(person);

            var person2 = deer.Location;

            //Console.WriteLine(person.Count);

            //for (var i = deer.Job.JobDrawbacks.Count - 1; i >= 0; i--)
            //{
            //    var drawback = deer.Job.JobDrawbacks.ToArray()[i].Drawback;
            //    Console.Write("\t");
            //    Console.WriteLine(drawback);
            //}
        }

        DbSet<Drawback> drawbacks = context.Drawbacks;

        foreach (var drawback in drawbacks)
        {
            DrawbackDetails detail = drawback.DrawbackDetail;
        }
        
        Console.ForegroundColor = ConsoleColor.White;
    }
}
