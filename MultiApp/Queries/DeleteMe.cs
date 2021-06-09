using System;
using CoreMultiLib;
using Microsoft.EntityFrameworkCore;

namespace EF_BeaversLife.Queries
{
    public class DeleteMe
    {
        /// <summary>
        /// Include is NOT needed.
        /// </summary>
        public void DeleteMe1()
        {
            using var context = new AnimalContext();

            var clubs = context.Clubs.Include(item => item.Grades);

            Console.ForegroundColor = ConsoleColor.Magenta;

            foreach (var club in clubs)
            {
                Console.WriteLine(club);

                foreach (var grade in club.Grades)
                {
                    Console.Write("\t");
                    Console.WriteLine(grade);

                    var gradeClub = grade.Club;
                    Console.Write("\t");
                    Console.Write("\t");
                    Console.WriteLine(gradeClub);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}