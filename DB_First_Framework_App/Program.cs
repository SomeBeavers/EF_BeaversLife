using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
                var likes = comment.Likes;
                Console.WriteLine(likes.FirstOrDefault()?.CommentId);
            }

            Console.ReadLine();
            context.Dispose();
        }
    }
}