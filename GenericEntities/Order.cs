namespace EF_TestFixes;

public class Order : Entity<int>
{
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public virtual ICollection<Person<int>> Persons { get; set; }
}