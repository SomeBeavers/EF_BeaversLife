namespace FrameworkLib_Common.NewFolder1
{
    public class Consequence
    {
        public string Name { get; set; } = null!;

        public override string ToString()
        {
            return $"Consequence : Name = {Name}";
        }
    }
}