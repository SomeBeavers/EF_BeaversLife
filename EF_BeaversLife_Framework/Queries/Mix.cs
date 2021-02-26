using System;
using System.Linq;
using FrameworkLib_Common;

namespace EF_BeaversLife_Framework.Queries
{
    public class Mix
    {
        public void UseCustomIdName()
        {
            using var context = new AnimalContext();
            var       animals = context.Animals.Where(animal => animal.CustomIdName == 1);

            Console.ForegroundColor = ConsoleColor.Magenta;

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
                if (animal.Clubs != null)
                {
                    foreach (var club in animal.Clubs)
                    {
                        Console.Write("\t");
                        Console.WriteLine(club);
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}