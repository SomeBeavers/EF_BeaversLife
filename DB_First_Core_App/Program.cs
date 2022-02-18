// See https://aka.ms/new-console-template for more information

using DB_First_Core_Lib.Models;

using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

using var context = new AdventureWorksContext();

DbSet<Address> contextAddresses = context.Addresses;
foreach (Address contextAddress in contextAddresses)
{
    var entityAddresses = contextAddress.BusinessEntityAddresses;
}