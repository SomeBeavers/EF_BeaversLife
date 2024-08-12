using CoreLib_Common.DTOs;

using Microsoft.Data.SqlClient;

namespace EF_BeaversLife.Queries;


public class UseRawSql
{
    public async Task<List<BeaverDto>> GetBeaver(CancellationToken cancellationToken)
    {
        using var context = new AnimalContext();
        var data = await context.Set<BeaverDto>().FromSqlRaw(
            "EXEC dbo.GetBeavers @Fluffiness, @Size",
            new SqlParameter("@Fluffiness", 1),
            new SqlParameter("@Size", 12)
        ).ToListAsync(cancellationToken);
        Console.ForegroundColor = ConsoleColor.Magenta;
        foreach (var beaver in data)
        {


            Console.Write("\t");
            Console.WriteLine(beaver.Id);
        }

        Console.ForegroundColor = ConsoleColor.White;
        return data;
    }

    public void UseRawSql1()
    {
        using var context = new AnimalContext();

        var foods = context.Food.FromSqlRaw("select * from Food where Title = {0}", "Pizza")
                           .Include(food => food.Animal)
            ;

        Console.ForegroundColor = ConsoleColor.Magenta;
        foreach (var food in foods)
        {
            Console.WriteLine(food);

            Console.Write("\t");
            Console.WriteLine(food.Animal);
        }

        Console.ForegroundColor = ConsoleColor.White;
    }

    public void UseRawSql2(string pizza)
    {
        using var context = new AnimalContext();

        var foods = context.Food.FromSqlInterpolated($"select * from Food where Title = {pizza}")
                           .Include(food => food.Animal)
            ;

        Console.ForegroundColor = ConsoleColor.Magenta;
        foreach (var food in foods)
        {
            Console.WriteLine(food);

            Console.Write("\t");
            Console.WriteLine(food.Animal);
        }

        Console.ForegroundColor = ConsoleColor.White;
    }
}
