using System;
using CoreMultiLib;
using Microsoft.EntityFrameworkCore;

namespace EF_BeaversLife.Queries
{
    public class Preprocessor
    {
        /// <summary>
        /// 
        /// </summary>
        public void Preprocessor1()
        {
            using var context = new AnimalContext();

            var clubs = context.Clubs;

            Console.ForegroundColor = ConsoleColor.Magenta;

            foreach (var club in clubs)
            {
                Console.WriteLine(club);

                foreach (var grade in club.Grades)
                {
                    Console.Write("\t");
                    Console.WriteLine(grade);

#if !NET5_0
                    if (grade?.Animal?.Job?.JobDrawbacks != null)
                    {
                        foreach (var drawback in grade.Animal.Job.JobDrawbacks)
                        {
                            Console.Write("\t");
                            Console.Write("\t");
                            Console.WriteLine(drawback.Drawback);
                        }
                    }
#endif
#if NET5_0
                    var clubLocations = grade.Club.Locations;
#endif
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Preprocessor2()
        {
            using var context = new AnimalContext();

            var animals = context.Animals;

            Console.ForegroundColor = ConsoleColor.Magenta;
#if NET5_0
            foreach (var animal in animals)
            {
                var animalJob = animal.Job;
            }
#else
            foreach (var animal in animals)
            {
                var animalJob = animal.Clubs;
            }
#endif

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}