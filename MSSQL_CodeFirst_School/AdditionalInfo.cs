namespace MSSQL_CodeFirst_School
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdditionalInfos")]
    public partial class AdditionalInfo
    {
        public int AdditionalInfoID { get; set; }

        public int StudentGradeId { get; set; }

        public virtual StudentGrade StudentGrade { get; set; }
    }
}
