using System;
using System.Collections.Generic;

namespace PostgreSQL_Core_App;

public partial class OnlineCourse
{
    public int CourseId { get; set; }

    public string Url { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;
}
