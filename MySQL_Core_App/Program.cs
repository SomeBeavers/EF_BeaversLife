using System;
using Microsoft.EntityFrameworkCore;
using MySQL_Core_Lib;

namespace MySQL_Core_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            TestCanonicalMethods.Method();
            ExecuteQueries();

            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void ExecuteQueries()
        {
            using var context = new EmployeesContext();

            var departments = context.Departments.Include(d => d.DeptEmps);

            foreach (var department in departments)
            {
                Console.WriteLine(department.DeptEmps.Count);
            }
        }
    }
}
