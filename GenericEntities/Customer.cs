using System.ComponentModel.DataAnnotations;
using EF_TestFixes.Model;

namespace EF_TestFixes;

public partial class Customer : Entity<int>
{
    public string Name { get; set; }
    // Navigation property
    public virtual ICollection<Order> Orders { get; set; }
}

public partial class Customer
{
    public virtual ICollection<Invoice> Invoices { get; set; }
}