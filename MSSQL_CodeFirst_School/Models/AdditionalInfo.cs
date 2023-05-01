using System.ComponentModel.DataAnnotations.Schema;

namespace MSSQL_CodeFirst_School.Models
{
    [Table("AdditionalInfos")]
    public partial class AdditionalInfo
    {
        public int AdditionalInfoID { get; set; }

        public int StudentGradeId { get; set; }

        public virtual StudentGrade StudentGrade { get; set; }
    }
}
