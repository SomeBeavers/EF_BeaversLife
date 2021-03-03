using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
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
    }

    public static class Ext
    {
        public static IQueryable<Animal> ExtensionMethod(this DbSet<Animal> a)
        {
            return a.Include(item => item.Clubs);
        }
    }
}