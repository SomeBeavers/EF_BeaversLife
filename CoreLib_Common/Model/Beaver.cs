namespace CoreLib_Common.Model;

//[Table("Beaver")]
public class Beaver : Animal
{
    private FluffinessEnum _fluffiness;

    public FluffinessEnum Fluffiness
    {
        get => _fluffiness;
        set => _fluffiness = value;
    }

    public int            Size       { get; set; }

    public override string ToString()
    {
        return @$"{base.ToString()} Beaver: Fluffiness = {this.Fluffiness} Size = {this.Size}";
    }
}

public enum FluffinessEnum
{
    NotFluffy,
    Fluffy,
    VeryFluffy
}
