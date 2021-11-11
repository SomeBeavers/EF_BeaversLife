using CoreLib_Common.Model;

namespace MSSQL_Core_App.Queries
{
    internal class UseQuery
    {
        /// <summary>
        /// Include is needed.
        /// </summary>
        public void UseQuery1()
        {
            using var context = new AnimalContext();

            Animal animal = context.Animals.First();
            List<ICollection<Grade>> grades = context.Entry(animal)
                .Collection(animal => animal.Clubs)
                .Query()
                .Select(club => club.Grades)
                .ToList();

            Console.ForegroundColor = ConsoleColor.Magenta;
            //foreach (ICollection<Grade> grades2 in grades)
            //{
            //    foreach (Grade grade in grades2)
            //    {
            //        Console.WriteLine(grade);
            //    }
            //}

            foreach (var club in animal.Clubs)
            {
                Console.WriteLine(club);
                foreach (var grade in club.Grades)
                {
                    Console.WriteLine(grade);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
