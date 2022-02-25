using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.Model
{
    public partial class StudentGrade
    {
        public StudentGrade()
        {
            AdditionalInfos = new HashSet<AdditionalInfo>();
            Comments = new HashSet<Comment>();
        }

        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public decimal? Grade { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Person Student { get; set; } = null!;
        public virtual ICollection<AdditionalInfo> AdditionalInfos { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
