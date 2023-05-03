using MSSQL_Core_App.Models;

using var db = new SchoolContext();

await foreach (Comment dbComment in db.Comments)
{
    foreach (CommentTag tag in dbComment.CommentTags)
    {
        
    }
}