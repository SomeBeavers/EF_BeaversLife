using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSQL_CodeFirst_School
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Model1())
            {
                //var query = db.Courses.OrderBy(b => b.Title);

                //foreach (var item in query)
                //{
                //    Console.WriteLine(item.Department.Name);
                //    Console.WriteLine(item.OnlineCourse);
                //    Console.WriteLine(item.People);
                //    Console.WriteLine(item.StudentGrades);
                //}

                var persons = db.People;

                foreach (var person in persons)
                {
                    Console.WriteLine(person.FirstName);
                    foreach (var pet in person.Pets)
                    {
                        
                        Console.WriteLine("\t"+ pet.Name);
                    }

                    Console.WriteLine(person.OfficeAssignment);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
