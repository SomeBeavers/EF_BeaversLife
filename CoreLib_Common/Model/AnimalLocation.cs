namespace CoreLib_Common.Model
{
    // Table-valued functions
    public class AnimalLocation
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"AnimalLocation : Name = {Name} Address = {Address}";
        }
    }
}