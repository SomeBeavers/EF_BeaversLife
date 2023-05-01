namespace MSSQL_CodeFirst_School.Models
{
    public partial class Like
    {
        public int id { get; set; }

        public int? CommentId { get; set; }

        public virtual Comment Comment { get; set; }
    }
}
