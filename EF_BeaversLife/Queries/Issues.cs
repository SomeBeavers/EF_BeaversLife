using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using CoreLib_Common;
using CoreLib_Common.Model;
using Microsoft.EntityFrameworkCore;

namespace EF_BeaversLife.Queries
{
    public class Issues
    {
        /// <summary>
        ///     BUG: https://youtrack.jetbrains.com/issue/RSRP-481612
        ///     Extension method with Include is used.
        /// </summary>
        public void RSRP_481612()
        {
            using var context     = new AnimalContext();
            var       animals     = context.Animals.ExtensionMethod();
            var       animalsList = animals.ToImmutableList();

            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var animal in animalsList)
            {
                Console.WriteLine(animal);
                if (animal.Clubs != null)
                {
                    var s = animal.Clubs.ToList();
                    foreach (Club club in animal.Clubs)
                    {
                        Console.Write("\t");
                        Console.WriteLine(club);
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        ///     BUG: https://youtrack.jetbrains.com/issue/RSRP-481598
        /// </summary>
        public void RSRP_481598()
        {
            using var            context          = new AnimalContext();
            IQueryable<Drawback> contextDrawbacks = context.Drawbacks.AsQueryable();
            IQueryable<Drawback> drawbacks =
                contextDrawbacks.Include(d => d.Clubs)
                                .ThenInclude(c => c.Animals) ?? contextDrawbacks;

            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var drawback in drawbacks)
            {
                Console.WriteLine(drawback);
                List<Club> clubs = (drawback.Clubs?.ToList() ?? null)!;

                if (clubs != null)
                {
                    foreach (var club in clubs)
                    {
                        Console.Write("\t");
                        Console.WriteLine(club);
                        if (club.Animals != null)
                        {
                            foreach (var animal in club.Animals)
                            {
                                Console.Write("\t");
                                Console.Write("\t");
                                Console.WriteLine(animal);
                            }
                        }
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// BUG: https://youtrack.jetbrains.com/issue/RSRP-481553
        /// Include is needed.
        /// </summary>
        public static async Task RSRP_481553()
        {
            await using var context = new AnimalContext();
            var crows = context.Crows
                //.Include(c => c.Grades)
                ;

            Console.ForegroundColor = ConsoleColor.Magenta;
            await crows.ForEachAsync(crow =>
            {
                Console.WriteLine(crow);
                if (crow.Grades != null)
                {
                    foreach (var grade in crow.Grades)
                    {
                        Console.Write("\t");
                        Console.WriteLine(grade);
                    }
                }
            });

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// BUG: https://youtrack.jetbrains.com/issue/RSRP-481553
        /// Include is needed.
        /// </summary>
        public static void RSRP_481553_Part2()
        {
            using var context   = new AnimalContext();
            var drawbacks = context.Drawbacks
                //.Include(d => d.Clubs)
                //.ThenInclude(c => c.Animals)
                ;

            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var drawback in drawbacks)
            {
                Console.WriteLine(drawback);
                drawback.Clubs?.ToList().ForEach(club =>
                {
                    Console.Write("\t");
                    if (club.Animals != null)
                    {
                        Console.WriteLine(club.Animals.Count);
                    }
                });
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// BUG: https://youtrack.jetbrains.com/issue/RSRP-481591
        /// Include is NOT needed as variable is reassigned.
        /// </summary>
        public void RSRP_481591()
        {
            using var context = new AnimalContext();
            var       food    = context.Food;
            food = null;

            //food = context.Food;

            Console.ForegroundColor = ConsoleColor.Magenta;
            if (food != null)
            {
                foreach (var food1 in food)
                {
                    Console.WriteLine(food1);
                    if (food1.Drawbacks != null)
                    {
                        foreach (var drawback in food1.Drawbacks)
                        {
                        }
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public static class Ext
    {
        public static IQueryable<Animal> ExtensionMethod(this DbSet<Animal> a)
        {
            return a.Include(item => item.Clubs);
        }
    }
}