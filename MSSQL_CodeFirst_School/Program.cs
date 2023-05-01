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
                // Display all Blogs from the database 
                var query = from b in db.Courses
                            orderby b.Title
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Department.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
