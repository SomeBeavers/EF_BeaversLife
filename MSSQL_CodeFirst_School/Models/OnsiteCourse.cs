using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSSQL_CodeFirst_School.Models
{
    [Table("OnsiteCourse")]
    public partial class OnsiteCourse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        [Required]
        [StringLength(50)]
        public string Days { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Time { get; set; }

        public virtual Course Course { get; set; }
    }
}
