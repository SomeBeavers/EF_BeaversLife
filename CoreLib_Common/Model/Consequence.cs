namespace CoreLib_Common.Model
{
    public class Consequence
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Consequence : Name = {Name}";
        }
    }
}