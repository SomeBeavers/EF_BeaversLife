using System;
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
    }
}