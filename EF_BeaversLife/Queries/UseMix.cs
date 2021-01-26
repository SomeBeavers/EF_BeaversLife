using System;
using System.Linq;
using CoreLib_Common;
using Microsoft.EntityFrameworkCore;

namespace EF_BeaversLife.Queries
{
    public class UseMix
    {
        public void PrintTest()
        {
            using var context = new AnimalContext();
            var unused = context.Clubs;

            try
            {
                var firstBeaver = context.Beavers
                                         // includes
                                         .Include(x => x.Clubs)
                                         .Include(x => x.Grades)
                                         .Include(x => x.Job)
                                         .ThenInclude(j => j.JobDrawbacks)
                                         .ThenInclude(jd => jd.Drawback)
                                         .Include(x => x.Food)
                                         .ThenInclude(x => x.Drawbacks)
                                         // other
                                         .OrderBy(x => x.Id)
                                         .First();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(firstBeaver);

                if (firstBeaver.Clubs != null)
                {
                    foreach (var club in firstBeaver.Clubs)
                    {
                        Console.Write("\t");

                        Console.WriteLine(club);

                        foreach (var location in club.Locations)
                        {
                            Console.Write("\t");
                            Console.Write("\t");

                            Console.WriteLine(location);
                        }
                    }
                }

                if (firstBeaver.Grades != null)
                {
                    foreach (var grade in firstBeaver.Grades)
                    {
                        Console.Write("\t");

                        Console.WriteLine(grade);
                    }
                }

                Console.Write("\t");

                Console.WriteLine(firstBeaver.Job);

                if (firstBeaver.Job.JobDrawbacks != null)
                    foreach (var drawback in firstBeaver.Job.JobDrawbacks)
                    {
                        Console.Write("\t");
                        Console.Write("\t");

                        Console.WriteLine(drawback.Drawback);

                        Console.Write("\t");
                        Console.Write("\t");
                        Console.Write("\t");

                        Console.WriteLine(drawback.Drawback.Consequence);
                    }

                Console.Write("\t");

                Console.WriteLine(firstBeaver.Food);

                if (firstBeaver.Food.Drawbacks != null)
                {
                    foreach (var drawback in firstBeaver.Food.Drawbacks)
                    {
                        Console.Write("\t");
                        Console.Write("\t");

                        Console.WriteLine(drawback);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintTest2()
        {
            using var context = new AnimalContext();

            var products = context.Products;
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var product in products)
            {
                Console.WriteLine(product["Id"]);
                Console.WriteLine(product["CategoryId"]);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        /// <summary>
        ///     FirstOrDefault on strings.
        /// </summary>
        public void PrintTest3()
        {
            using var context = new AnimalContext();

            var animals = context.Animals.Where(animal => animal.Name.FirstOrDefault() == 'S').ToList();

            Console.ForegroundColor = ConsoleColor.Magenta;

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        ///     OrderBy + ThenBy.
        /// </summary>
        public void PrintTest4()
        {
            using var context = new AnimalContext();

            // ReSharper disable once StringCompareToIsCultureSpecific
            var clubs = context.Clubs.OrderBy(club => club.Title.CompareTo("CornLovers") == 0).ThenBy(club => club.Id)
                .Include(club => club.Grades);

            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var club in clubs)
            {
                Console.WriteLine(club);
                foreach (var grade in club.Grades)
                {
                    Console.Write("\t");
                    Console.WriteLine(grade);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}