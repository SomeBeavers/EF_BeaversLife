namespace CoreLib_Common.Model
{
    public class JobDrawback
    {
        public int JobId { get; set; }
        public int DrawbackId { get; set; }

        public Job Job { get; set; } = null!;
        public Drawback Drawback { get; set; } = null!;
    }
}