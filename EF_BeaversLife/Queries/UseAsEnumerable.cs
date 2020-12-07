using System;
using System.Linq;
using CoreLib_Common;
using CoreLib_Common.Model;
using Microsoft.EntityFrameworkCore;

namespace EF_BeaversLife.Queries
{
    public class UseAsEnumerable
    {
        /// <summary>
        ///     AsEnumerable for client evaluation.
        /// </summary>
        public void UseAsEnumerable1()
        {
            using var context = new AnimalContext();

            var drawbacks = context.Drawbacks.Include(d => d.Clubs).Where(d => d.Clubs.Count > 2)
                .AsEnumerable()
                .Where(drawback => IsLongTitle(drawback));

            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var drawback in drawbacks)
            {
                Console.WriteLine(drawback);
                if (drawback.Clubs != null)
                    foreach (var club in drawback.Clubs)
                    {
                        Console.Write("\t");
                        Console.WriteLine(club);
                    }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private bool IsLongTitle(Drawback drawback)
        {
            return drawback.Title.Length > 5;
        }
    }
}