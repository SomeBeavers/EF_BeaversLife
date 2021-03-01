using System;
using System.Data.Entity;
using System.Linq;
using FrameworkLib_Common;

namespace EF_BeaversLife_Framework.Queries
{
    public class UseInclude
    {
        /// <summary>
        ///     Include is needed.
        /// </summary>
        public void UseDbQueryIncludeWithStringPath()
        {
            using var context  = new AnimalContext();
            var foodList = context.VeganFood
                                  .Include("Drawbacks").Include("Animal.Grades")
                ;

            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var food in foodList)
            {
                Console.WriteLine(food);

                if (food.Drawbacks != null)
                {
                    foreach (var drawback in food.Drawbacks)
                    {
                        Console.Write("\t");
                        Console.WriteLine(drawback);
                    }
                }

                Console.Write("\t");
                Console.Write("\t");
                Console.WriteLine(food.Animal);

                if (food.Animal?.Grades != null)
                {
                    foreach (var grade in food.Animal.Grades)
                    {
                        Console.Write("\t");
                        Console.Write("\t");
                        Console.Write("\t");
                        Console.WriteLine(grade);
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        ///     Include is needed.
        /// </summary>
        public void UseExtensionInclude1()
        {
            using var context  = new AnimalContext();
            var foodList = context.VeganFood
                                  .Include(food => food.Drawbacks).Include(food => food.Animal.Grades)
                ;

            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var food in foodList)
            {
                Console.WriteLine(food);

                if (food.Drawbacks != null)
                {
                    foreach (var drawback in food.Drawbacks)
                    {
                        Console.Write("\t");
                        Console.WriteLine(drawback);
                    }
                }

                Console.Write("\t");
                Console.Write("\t");
                Console.WriteLine(food.Animal);

                if (food.Animal?.Grades != null)
                {
                    foreach (var grade in food.Animal.Grades)
                    {
                        Console.Write("\t");
                        Console.Write("\t");
                        Console.Write("\t");
                        Console.WriteLine(grade);
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}