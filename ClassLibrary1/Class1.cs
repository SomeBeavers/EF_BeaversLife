using ClassLibrary1.Model;

using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1
{
    public class Class1
    {
        /// <summary>
        /// 
        /// </summary>
        public void Test()
        {
            using var context = new SchoolContext1();

            var comments = context.Comments1;

            Console.ForegroundColor = ConsoleColor.Magenta;


            var comment = comments.First();//comment

            var a = comment.StudentGradeEnrollment;

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}