namespace MSSQL_CodeFirst_School
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdditionalTable")]
    public partial class AdditionalTable
    {
        public int id { get; set; }

        public int? CommentId { get; set; }

        public virtual Comment Comment { get; set; }
    }
}
