namespace EF_BeaversLife.Queries
{
    public class UseSet
    {
        /// <summary>
        /// Include is needed.
        /// </summary>
        public void UseSet1()
        {
            using var context = new AnimalContext();

            var beavers = context.Set<Beaver>();

            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var beaver in beavers)
            {
                Console.WriteLine(beaver);

                if (beaver.Clubs != null)
                {
                    foreach (var club in beaver.Clubs)
                    {
                        Console.Write("\t");
                        Console.WriteLine(club);
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}