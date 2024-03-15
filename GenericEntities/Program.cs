using EF_TestFixes;

namespace GenericEntities;

internal class Program
{
    static void Main(string[] args)
    {
        var context = new MyDbContext();
        foreach (var order in context.Orders)
        {
            var firstOrDefault = order.Customer.Orders.FirstOrDefault();
        }

        foreach (var invoice in context.Invoices)
        {
            invoice.Customer.Orders.FirstOrDefault();
        }


        foreach (var person in context.Persons)
        {
            var personsCount = person.Order.Customer.Orders.Count();
            var invoicesCount = person.Invoice.Customer.Orders.FirstOrDefault();
        }

        foreach (var person in context.PersonsString)
        {
            var personsCount = person.Order.Customer.Orders.Count();
            var invoicesCount = person.Invoice.Customer.Orders.FirstOrDefault();
        }
    }
}
