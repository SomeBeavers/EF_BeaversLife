using System.ComponentModel.DataAnnotations;

namespace EF_TestFixes.Model;

public class Invoice : Entity<string>
{
    [MaxLength(100)]
    public string InvoiceNumber { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    // Navigation property
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<Person<string>> Persons { get; set; }
}

