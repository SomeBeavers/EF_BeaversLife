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
            var s = context.Clubs;

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

                if (firstBeaver.Job?.JobDrawbacks != null)
                {
                    foreach (var drawback in firstBeaver.Job.JobDrawbacks)
                    {
                        Console.Write("\t");
                        Console.Write("\t");

                        Console.WriteLine(drawback.Drawback);
                    }
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
        }

        public void PrintTest2()
        {
            using var context = new AnimalContext();

            var products = context.Products;

            foreach (var product in products)
            {
                Console.WriteLine(product["Id"]);
                Console.WriteLine(product["CategoryId"]);
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();
        }
    }
}