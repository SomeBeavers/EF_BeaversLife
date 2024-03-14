using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace PostgreSQL_Core_App.Queries;
internal class TestCanonicalMethods
{
    public static void DateTimeMethods()
    {
        using var context = new SchoolContext();
        var people = context.People;
        var dep = context.Departments;

        //supported
        Console.WriteLine(dep.Where(d => d.StartDate.CompareTo(DateTime.Today) > 2).ToList());
        Console.WriteLine(people.Where(a => a.HireDate!.Value.CompareTo(a.EnrollmentDate!.Value) > 2).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.AddYears(3).Equals(DateTime.Today)).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.AddDays(3).Equals(DateTime.Today)).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.AddHours(3).Equals(DateTime.Today)).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.AddMinutes(3).Equals(DateTime.Today)).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.AddMonths(3).Equals(DateTime.Today)).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.AddSeconds(3).Equals(DateTime.Today)).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.ToLocalTime().Equals(DateTime.Today)).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.ToUniversalTime().Equals(DateTime.Today)).ToList());
        Console.WriteLine(people.Where(a => a.HireDate!.Value.Equals(DateTime.Today)).ToList());
        Console.WriteLine(people.Where(p => p.HireDate!.ToString()!.EndsWith("5")).ToList());
        Console.WriteLine(dep.Where(d => DateTime.Compare(d.StartDate, DateTime.Today) > 3).ToList());
        Console.WriteLine(dep.Where(d => DateTimeOffset.Compare(d.StartDate, DateTimeOffset.Now) > 3).ToList());
        dep.Where(d => TimeSpan.FromDays(5).Equals(d.StartDate));
        TimeSpan res;
        dep.Where(d => TimeSpan.TryParse(d.StartDate.ToString(), out res) == true);

        Console.WriteLine(dep.Where(d => d.StartDate.ToString().EndsWith("5")).ToList());

        Console.WriteLine(dep.Where(d => Math.Sign(Convert.ToInt32(d.Budget)) == 0));
        Console.WriteLine(dep.Where(d => Math.Round(Convert.ToDouble(d.Budget)) > 3));

        //not supported
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.GetValueOrDefault().Equals(DateTime.Today)).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.AddMilliseconds(3).Equals(DateTime.Today)).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.AddTicks(3).Equals(DateTime.Today)).ToList());
        Console.WriteLine(people.Where(p => p.HireDate!.Value.IsDaylightSavingTime().Equals(true)).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.GetDateTimeFormats().Equals("")).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.GetHashCode().Equals(5)).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.GetTypeCode().Equals("")).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.ToBinary().Equals(DateTime.Today)).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.ToFileTime().Equals(DateTime.Today)).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.ToFileTimeUtc().Equals(DateTime.Today)).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.ToLongDateString().Equals(DateTime.Today)).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.ToLongTimeString().Equals(DateTime.Today)).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.ToShortDateString().Equals(DateTime.Today)).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.ToShortTimeString().Equals(DateTime.Today)).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.ToOADate().Equals(DateTime.Today)).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.Subtract(DateTime.Today).Equals(DateTime.Today)).ToList());
        Console.WriteLine(people.Where(p => p.EnrollmentDate!.Value.Add(TimeSpan.FromMinutes(5)).Equals(DateTime.Today)).ToList());
        Console.WriteLine(dep.Where(d => DateTime.IsLeapYear(d.StartDate.Year) == true).ToList());
    }

    public static void Method()
    {
        using var context = new SchoolContext();
        var people = context.People;

        foreach (var person in people)
        {
            Console.WriteLine(EF.Functions.FuzzyStringMatchLevenshteinLessEqual(person.FirstName, person.LastName, 5));
        }
        Console.WriteLine(people.Where(p => EF.Functions.TrigramsAreSimilar(p.FirstName, p.LastName)));
    }
}
