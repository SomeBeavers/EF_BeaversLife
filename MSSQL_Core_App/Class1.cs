using Microsoft.EntityFrameworkCore;

using MSSQL_Core_App.Models;

class MyClass
{
    private static void UseInclude1(bool isRead = false)
    {
        using var context = new SchoolContext();

        IQueryable<Person> persons = context.People;

        if (isRead)
        {
            persons = context.People.Include(item => item.StudentGrades);
        }

        if (isRead)
        {
            foreach (var person in persons)
            {
                Console.WriteLine(person.StudentGrades.Count);
            }
        }

    }
}