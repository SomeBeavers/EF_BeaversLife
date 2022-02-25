using B;

namespace EF_BeaversLife.Queries;

public class DeleteMe2
{
    /// <summary>
    /// 
    /// </summary>
    public void Test()
    {
        using var context = new AnimalContext();

        var additionalInfos = context.AdditionalInfos
            //.Include(ai => ai.AdditionalInfoDetailed)
            ;

        Console.ForegroundColor = ConsoleColor.Magenta;

        foreach (var additionalInfo in additionalInfos)
        {
            Console.WriteLine(additionalInfo);
            Console.WriteLine(additionalInfo.AdditionalInfoDetailed);
        }

        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Test2()
    {
        using var context = new NewContext();

        var dbSet = context.Animals;

        Console.ForegroundColor = ConsoleColor.Magenta;

        foreach (var newModel3 in dbSet)
        {
            var animals = newModel3.HatedBy;
        }

        Console.ForegroundColor = ConsoleColor.White;
    }
}