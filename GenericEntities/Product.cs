using System.ComponentModel.DataAnnotations;

namespace EF_TestFixes;

public class Product : Entity<int>
{
    [MaxLength(100)]
    public string Name { get; set; }
    // Navigation property
    public virtual ICollection<Order> Orders { get; set; }
}