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
        private static DbSet<Person> _dbPeople;

        static void Main(string[] args, bool a)
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

                _dbPeople = db.People;
                IQueryable<Person> persons = _dbPeople;

                Person person;

                if (a)
                {
                    person = _dbPeople.MyExtension().FirstOrDefault();
                }
                else
                {
                    person = _dbPeople.FirstOrDefault();
                }


                Console.WriteLine(person.FirstName);
                    foreach (var pet in person.Pets)
                    {
                        
                        Console.WriteLine("\t"+ pet.Name);
                    }

                    OnlinePerson personOnlinePerson = person.OnlinePerson;
                

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }

    public static class Extensions
    {
        public static IQueryable<Person> MyExtension(this DbSet<Person> persons)
        {
            return persons.Include(p => p.Pets);
        }
    }
}
