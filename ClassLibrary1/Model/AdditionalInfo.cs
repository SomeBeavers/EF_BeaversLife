using System;
using System.Collections.Generic;

namespace ClassLibrary1.Model
{
    public partial class AdditionalInfo
    {
        public int AdditionalInfoId { get; set; }
        public int StudentGradeId { get; set; }

        public virtual StudentGrade StudentGrade { get; set; } = null!;
    }
}
