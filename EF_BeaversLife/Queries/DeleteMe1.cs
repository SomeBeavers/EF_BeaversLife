﻿using System;
using System.Linq;
using CoreLib_Common;

namespace EF_BeaversLife.Queries
{
    public class DeleteMe1
    {
        /// <summary>
        ///     Include is needed.
        /// </summary>
        public void UseInverseProperties()
        {
            using var context = new AnimalContext();
            var       persons = context.Persons;

            Console.ForegroundColor = ConsoleColor.Magenta;

            foreach (var person in persons)
            {
                Console.WriteLine(person);
                foreach (var animalLoved in person.AnimalsLoved)
                {
                    Console.Write("\t");
                    Console.WriteLine(animalLoved);
                }

                foreach (var animalHated in person.AnimalsHated)
                {
                    Console.Write("\t");
                    Console.Write("\t");
                    Console.WriteLine(animalHated);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Include is needed.
        /// </summary>
        public void DeleteMe2()
        {
            using var context = new AnimalContext();

            foreach (var elf in context.Elves)
            {
                Console.WriteLine(elf);

                var person = elf.Deer.LovedBy;

                for (var i = elf.Deer.Job.JobDrawbacks.Count - 1; i >= 0; i--)
                {
                    var drawback = elf.Deer.Job.JobDrawbacks.ToArray()[i].Drawback;
                    Console.Write("\t");
                    Console.WriteLine(drawback);
                }
            }

            Console.ForegroundColor = ConsoleColor.Magenta;


            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteMe3()
        {
            using var context = new AnimalContext();

            Console.ForegroundColor = ConsoleColor.Magenta;

            foreach (var food in context.Food)
            {
                Console.WriteLine(food);

                foreach (var club in food.Animal.Clubs)
                {
                }

                foreach (var drawback in food.Drawbacks)
                {
                    var consequence = drawback.Consequence;
                    var drawback1   = drawback.JobDrawbacks.First().Job;
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}