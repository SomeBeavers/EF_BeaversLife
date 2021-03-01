using System;
using System.Data.Entity;
using System.Linq;
using FrameworkLib_Common;

namespace EF_BeaversLife_Framework.Queries
{
    public class UseIncludeWithSelect
    {
        /// <summary>
        ///     Include is needed.
        /// </summary>
        public void UseIncludeWithSelect1()
        {
            using var context = new AnimalContext();
            var       beavers = context.Beavers.Include(b => b.Clubs.Select(club => club.Locations));

            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var beaver in beavers)
            {
                Console.WriteLine(beaver);

                if (beaver.Clubs != null)
                {
                    foreach (var club in beaver.Clubs)
                    {
                        foreach (var location in club.Locations)
                        {
                            Console.Write("\t");
                            Console.WriteLine(location);
                        }
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}