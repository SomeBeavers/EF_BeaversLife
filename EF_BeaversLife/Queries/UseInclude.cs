using System;
using System.Linq;
using CoreLib_Common;
using Microsoft.EntityFrameworkCore;

namespace EF_BeaversLife.Queries
{
    public class UseInclude
    {
        public void UseFilteredInclude1()
        {
            using var context = new AnimalContext();

            var clubs = context.Clubs
                .Include(club => club.Animals.Where(animal => animal.Name.Contains("Beaver")))
                .ThenInclude(animal => animal.Grades.Where(grade => grade.TheGrade > 4))
                .Include(club => club.Animals.Where(animal => animal.Name.Contains("Beaver")))
                .ThenInclude(a => a.Food).ToList();

            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var club in clubs)
            {
                Console.WriteLine(club);
                if (club.Animals != null)
                    foreach (var animal in club.Animals)
                    {
                        Console.Write("\t");
                        Console.WriteLine(animal);


                        Console.Write("\t");
                        Console.Write("\t");
                        Console.WriteLine(animal.Food);

                        if (animal.Grades != null)
                            foreach (var grade in animal.Grades)
                            {
                                Console.Write("\t");
                                Console.Write("\t");
                                Console.WriteLine(grade);
                            }
                    }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void UseFilteredInclude2()
        {
            using var context = new AnimalContext();

            var animals =
                    context.Animals.Include(animal => animal.Grades.OrderByDescending(grade => grade.TheGrade).Take(2))
                //.ThenInclude(grade => grade.Club)
                ;

            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
                if (animal.Grades != null)
                    foreach (var grade in animal.Grades)
                    {
                        Console.Write("\t");
                        Console.WriteLine(grade);

                        Console.Write("\t");
                        Console.Write("\t");
                        // TODO: Include me
                        Console.WriteLine(grade.Club);
                    }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}