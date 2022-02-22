namespace FrameworkLib_Common.Model;

//[Table("Animals")]
public class ExtractedClass
{
    public virtual Job     Job     { get; set; } = null!;
    public         int?    JobId   { get; set; }
    public virtual Person? LovedBy { get; set; }
    public virtual Person? HatedBy { get; set; }
}

public class Animal
{
    private          Food           _food          = null!;

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomIdName { get; set; }

    [MaxLength(128)]
    [Index]
    [IsUnicode(true)]
    public string? Name { get; set; }

    public         int                 Age     { get; set; }
    public virtual List<Club>?         Clubs   { get; set; }
    public virtual ICollection<Grade>? Grades  { get; set; }

    public virtual Food? Food { get; set; } = null!;
    //public virtual Food Food
    //{
    //    get => _food;
    //    set => _food = value;
    //}

    // Translates to string in db so Include is not needed.
    public string IpAddress { get; set; } = null!;

    public ExtractedClass ExtractedClass
    {
        get;
        set;
    }

    //public JsonDocument? Passport { get; set; }

    public override string ToString()
    {
        return $"Animal : Id = {CustomIdName} Name = {Name} IpAddress = {IpAddress}";
    }
}
