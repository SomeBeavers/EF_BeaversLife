using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MSSQL_CodeFirst_School.Models;

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

                IQueryable<Person> persons = db.People;
                 persons = db.People.MyExtension();

                foreach (var person in persons)
                {
                    Console.WriteLine(person.FirstName);
                    foreach (var pet in person.Pets)
                    {
                        
                        Console.WriteLine("\t"+ pet.Name);
                    }

                    OnlinePerson personOnlinePerson = person.OnlinePerson;
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }

    public static class Extensions
    {
        public static IQueryable<Person> MyExtension(this IQueryable<Person> persons)
        {
            return persons.Include(p => p.Pets);
        }
    }
}
