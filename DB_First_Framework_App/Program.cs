using System.Collections.Generic;

using DB_First_Framework_Lib;

namespace DB_First_Framework_App
{
    public class Program
    {
        public static void Main()
        {
            var context = new SchoolEntities();

            foreach (Comment comment in context.Comments)
            {
                var tags = comment.CommentTags;
            }

            context.Dispose();
        }
    }
}