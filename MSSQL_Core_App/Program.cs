using Microsoft.EntityFrameworkCore;

using MSSQL_Core_App.Models;

using var db = new SchoolContext();

 foreach (Comment dbComment in db.Comments)
 {
     var a = dbComment?.StudentGradeEnrollment?.Course.People;
     var a2 = dbComment?.CommentTags;
 }