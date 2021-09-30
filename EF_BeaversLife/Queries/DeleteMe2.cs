﻿namespace EF_BeaversLife.Queries;

public class DeleteMe2
{
    /// <summary>
    /// 
    /// </summary>
    public void Test()
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