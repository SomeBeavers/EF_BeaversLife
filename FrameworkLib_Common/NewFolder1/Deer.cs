namespace FrameworkLib_Common.NewFolder1
{
    //[Table("Deer")]
    public class Deer : Animal
    {
        public bool Horns { get; set; }

        public override string ToString()
        {
            return @$"{base.ToString()} Deer : Horns = {this.Horns}";
        }
    }
}