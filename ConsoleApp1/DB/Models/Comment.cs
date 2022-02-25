using System;
using System.Linq;

namespace ConsoleApp1.DB.Models;

public class Comment
{
    public int Id { get; set; }
    public virtual StudentGrade?   StudentGrade  { get; set; }
}

public class StudentGrade
{
    public         int Id { get; set; }
    public virtual Comment? Comment { get; set; }
}