namespace MSSQL_Core_App.Queries;

internal class UseSplittedTable
{
    /// <summary>
    /// Include is needed.
    /// </summary>
    public void UseSplittedTable1()
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
}
