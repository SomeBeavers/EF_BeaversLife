using System;
using System.Collections.Generic;
using System.Linq;
using CoreLib_Common;
using CoreLib_Common.Model;

namespace EF_BeaversLife.Queries
{
    public class UseLocalData
    {
        /// <summary>
        ///     Include is NOT needed.
        /// </summary>
        public void UseLocalData1()
        {
            using var context = new AnimalContext();
            context.Persons.Add(new Person
            {
                Name         = "BeaverPerson",
                AnimalsLoved = new List<Animal> {context.Crows.First()},
                AnimalsHated = new List<Animal> {context.Deers.First()}
            });

            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var person in context.Persons.Local)
            {
                Console.WriteLine(person);

                foreach (var lovedAnimal in person.AnimalsLoved)
                {
                    Console.Write("\t");
                    Console.WriteLine(lovedAnimal);
                }

                foreach (var hatedAnimal in person.AnimalsHated)
                {
                    Console.Write("\t");
                    Console.Write("\t");
                    Console.WriteLine(hatedAnimal);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        ///     Include is needed.
        /// </summary>
        public void UseLocalData2()
        {
            using var context = new AnimalContext();
            context.Persons.Add(new Person
            {
                Name         = "BeaverPerson",
                AnimalsLoved = new List<Animal> {context.Crows.First()},
                AnimalsHated = new List<Animal> {context.Deers.First()}
            });

            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var person in context.Persons.Local)
            {
                Console.WriteLine(person);

                foreach (var lovedAnimal in person.AnimalsLoved)
                {
                    Console.Write("\t");
                    Console.WriteLine(lovedAnimal);
                }

                foreach (var hatedAnimal in person.AnimalsHated)
                {
                    Console.Write("\t");
                    Console.Write("\t");
                    Console.WriteLine(hatedAnimal);
                }
            }

            foreach (var person in context.Persons)
            {
                Console.WriteLine(person);

                if (person.AnimalsLoved != null)
                {
                    foreach (var lovedAnimal in person.AnimalsLoved)
                    {
                        Console.Write("\t");
                        Console.WriteLine(lovedAnimal);
                    }
                }

                if (person.AnimalsHated != null)
                {
                    foreach (var hatedAnimal in person.AnimalsHated)
                    {
                        Console.Write("\t");
                        Console.Write("\t");
                        Console.WriteLine(hatedAnimal);
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}