namespace EF_TestFixes;

public class Type
{
    public string Name { get; set; }
    public virtual IList<Animal> Animals { get; set; }
}