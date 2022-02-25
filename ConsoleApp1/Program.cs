// See https://aka.ms/new-console-template for more information

using ConsoleApp1.DB;
using ConsoleApp1.DB.Models;

using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

using var context = new SchoolContext();

DbSet<Comment> comments = context.Comments;

var grade = comments?.FirstOrDefault()?.StudentGrade?.Comment;