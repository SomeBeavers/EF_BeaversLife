using System;
using System.Collections.Generic;

namespace MSSQL_Core_App.Models;

public partial class StudentGrade
{
    public int EnrollmentId { get; set; }

    public int CourseId { get; set; }

    public int StudentId { get; set; }

    public decimal? Grade { get; set; }

    public virtual ICollection<AdditionalInfo> AdditionalInfos { get; set; } = new List<AdditionalInfo>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Course Course { get; set; } = null!;

    public virtual Person Student { get; set; } = null!;
}
