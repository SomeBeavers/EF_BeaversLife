using MSSQL_Core_App;

await using var db = new BloggingContext();

await foreach (var blog in db.Blogs)
{
    var blogPosts = blog.Posts;
    Console.WriteLine($"Blog: {blog.Url}");
}   
