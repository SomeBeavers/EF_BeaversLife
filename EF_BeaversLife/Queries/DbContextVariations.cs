namespace MSSQL_Core_App.Queries;

public class DbContextVariations
{
    private AnimalContext context;
    private AnimalContext context2;

    /// <summary>
    ///     Include is needed.
    /// </summary>
    /// <param name="context"><see cref="DbContext"/> as parameter.</param>
    public void DbContextAsParameter()
    {
        var db = context.AdditionalInfos;
        var db2 = context2.AdditionalInfos;

        Console.ForegroundColor = ConsoleColor.Magenta;
        
        foreach (var info in db)
        {
            var b = info.Grades;
            var a = info.Clubs;
        }


        Console.ForegroundColor = ConsoleColor.White;
    }

    private AnimalContext GetAnimalContext(AnimalContext context)
    {
        return context;
    }
}