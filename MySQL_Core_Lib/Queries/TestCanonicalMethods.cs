using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Castle.Components.DictionaryAdapter.Xml;

using Microsoft.EntityFrameworkCore;


namespace MySQL_Core_Lib
{
    public class TestCanonicalMethods
    {
        public static void Method()
        {
            using var context = new EmployeesContext();
            var employees = context.Employees;
            var t = employees.Where(a => Convert.ToByte(a.HireDate) > 3).ToList();
            var date = employees.Where(a => a.HireDate.Date.CompareTo(a.BirthDate.Date) > 2).ToList();
            Console.WriteLine(employees.OrderByDescending(e => e.BirthDate).Select(e => new { date = e.BirthDate }));
            
            foreach (var employee in employees)
            {
                Console.WriteLine(EF.Functions.AsJson(employee.FirstName));
                Console.WriteLine(EF.Functions.Match(employee.FirstName, employee.LastName, MySqlMatchSearchMode.NaturalLanguage));
                Console.WriteLine(EF.Functions.JsonContains(employee.HireDate, employee.FirstName));
            }


        }
    }
}
