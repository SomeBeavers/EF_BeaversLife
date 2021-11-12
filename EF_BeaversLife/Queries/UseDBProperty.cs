namespace MSSQL_Core_App.Queries
{
    internal class UseDBProperty
    {
        public void UseEntryState() 
        {
            using var context = new AnimalContext();
            var drawback = context.Drawbacks.First();

            Console.ForegroundColor = ConsoleColor.Magenta;
            
            Console.WriteLine(context.Entry(drawback).State);
            
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
