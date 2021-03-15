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

        /// <summary>
        /// BUG: https://youtrack.jetbrains.com/issue/RSRP-481595
        /// </summary>
        public void RSRP_481595()
        {
            using var context = new AnimalContext();
            var       food    = context.Food ?? null;
            //var       food    = (context.Food ?? null)!;

            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var food1 in food)
            {
                Console.WriteLine(food1);
                List<Drawback> drawbacks = (food1.Drawbacks?.ToList() ?? null)!;

                if (drawbacks != null)
                {
                    foreach (var drawback in drawbacks)
                    {
                        if (drawback.Clubs != null)
                        {
                            foreach (var club in drawback.Clubs)
                            {
                                Console.Write("\t");
                                Console.WriteLine(club);
                            }
                        }
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// BUG: https://youtrack.jetbrains.com/issue/RSRP-481554
        /// </summary>
        public void RSRP_481554()
        {
            using var context     = new AnimalContext();
            using var transaction = context.Database.BeginTransaction();

            Console.ForegroundColor = ConsoleColor.Magenta;

            foreach (var normalFood in context.NormalFood)
            {
                Console.WriteLine(normalFood);
                if (normalFood.Drawbacks != null)
                {
                    foreach (var drawback in normalFood.Drawbacks)
                    {
                        Console.Write("\t");
                        Console.WriteLine(drawback);
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            transaction.Commit();
        }

        /// <summary>
        /// BUG: https://youtrack.jetbrains.com/issue/RSRP-481577
        /// </summary>
        public void RSRP_481577()
        {
            using var context = new AnimalContext();
            var beavers = context.Beavers.Include(beaver =>
                beaver.Grades.Where(grade => grade.TheGrade >= 4.0).OrderByDescending(grade => grade.TheGrade).Take(1));

            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var beaver in beavers)
            {
                Console.WriteLine(beaver);
                if (beaver.Grades != null)
                {
                    foreach (var grade in beaver.Grades)
                    {
                        Console.Write("\t");
                        Console.WriteLine(grade);
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// BUG: https://youtrack.jetbrains.com/issue/RSRP-481581
        /// </summary>
        public void RSRP_481581()
        {
            using var          context    = new AnimalContext();
            IQueryable<Animal> animals    = context.Deers.AsQueryable();
            var                newAnimals = animals;

            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var animal in newAnimals)
            {
                Console.WriteLine(animal);
                if (animal.Grades != null)
                {
                    foreach (var grade in (animal).Grades)
                    {
                        Console.Write("\t");
                        Console.WriteLine(grade);
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// BUG: https://youtrack.jetbrains.com/issue/RSRP-481581
        /// Include is needed.
        /// </summary>
        public void RSRP_481581_2()
        {
            using var          context    = new AnimalContext();
            IQueryable<Animal> animals = context.Deers.AsQueryable()
                //.Include(d => d.Elves)
                ;
            var                newAnimals = animals;

            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var animal in newAnimals)
            {
                Console.WriteLine(animal);

                var elves = ((Deer) animal).Elves;
                if (elves != null)
                {
                    foreach (var elf in elves)
                    {
                        Console.Write("\t");
                        Console.WriteLine(elf);
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// BUG: https://youtrack.jetbrains.com/issue/RSRP-481557
        /// </summary>
        public void RSRP_481557()
        {
            using var context   = new AnimalContext();
            var       drawbacks = context.Drawbacks;
            var       first     = drawbacks.First();
            context.Entry(first).Collection(d => d.Clubs).Load();

            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var drawback in drawbacks)
            {
                Console.WriteLine(drawback);
                if (drawback.Clubs != null)
                {
                    foreach (var club in drawback.Clubs)
                    {
                        Console.Write("\t");
                        Console.WriteLine(club);

                        foreach (var grade in club.Grades)
                        {
                            Console.Write("\t");
                            Console.Write("\t");

                            Console.WriteLine(grade);
                        }
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// BUG: https://youtrack.jetbrains.com/issue/RSRP-481559
        /// </summary>
        public void RSRP_481559()
        {
            using var context = new AnimalContext();
            var       animals = context.Animals;

            // start comment
            var       grades  = context.Entry(animals.Single(a => a.Id == 1)).Collection(a => a.Grades);
            grades.Load();
            // end comment

            // uncomment
            //context.Entry(animals.Single(a => a.Id == 1)).Collection(a => a.Grades).Query().Load();

            var count = grades.Query().Count();
            Console.WriteLine(count);

            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
                if (animal.Grades != null)
                {
                    foreach (var grade in animal.Grades)
                    {
                        Console.Write("\t");
                        Console.WriteLine(grade);
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// BUG: https://youtrack.jetbrains.com/issue/RSRP-481502
        /// </summary>
        public void RSRP_481502(bool boolParameter = false)
        {
            using var     context = new AnimalContext();
            DbSet<Person> persons = context.Persons;

            Console.ForegroundColor = ConsoleColor.Magenta;
            if (boolParameter)
            {
                // uncomment
                //persons.Include(p => p.AnimalsLoved);
                //persons.Include(p => p.AnimalsHated);
            }

            if (boolParameter)
            {
                foreach (var person in persons)
                {
                    Console.WriteLine(person.AnimalsLoved.Count);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// BUG: https://youtrack.jetbrains.com/issue/RSRP-481543
        /// </summary>
        public void RSRP_481543()
        {
            using var     context        = new AnimalContext();
            DbSet<Beaver> contextBeavers = context.Beavers;

            // DEXP-581354


            Console.ForegroundColor = ConsoleColor.Magenta;


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