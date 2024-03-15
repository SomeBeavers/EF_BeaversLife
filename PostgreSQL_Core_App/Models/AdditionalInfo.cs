using System;
using System.Collections.Generic;

namespace PostgreSQL_Core_App;

public partial class AdditionalInfo
{
    public int AdditionalInfoId { get; set; }

    public int StudentGradeId { get; set; }

    public virtual StudentGrade StudentGrade { get; set; } = null!;
}
