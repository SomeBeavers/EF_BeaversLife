namespace EF_BeaversLife.Queries
{
    public class DeleteMe3
    {
        /// <summary>
        /// 
        /// </summary>
        public void Test()
        {
            using var context = new AnimalContext();

            //var queryable = from p in context.Animals
            //                join t in context.Food
            //                    on new { p.Food.Id } equals new { t.Id } into gj
            //                from pt in gj.DefaultIfEmpty()
            //                select new
            //                {
            //                    PhotoUrl = p.Grades.FirstOrDefault(p => p.Age == 1).Id
            //                };

            var queryable = from p in context.Animals
                            join t in context.Food
                                on new { p.Food.Id } equals new { t.Id } into gj
                            from pt in gj.DefaultIfEmpty()
                            select new
                            {
                                PhotoUrl = p.Grades.FirstOrDefault(p => p.TheGrade == 1).Id
                            };

            Console.ForegroundColor = ConsoleColor.Magenta;


            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}