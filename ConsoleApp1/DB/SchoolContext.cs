using ConsoleApp1.DB.Models;

using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.DB;

public class SchoolContext: DbContext
{
    public virtual DbSet<Comment>? Comments { get; set; } = null;
}