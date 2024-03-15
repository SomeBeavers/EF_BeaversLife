using System;
using System.Collections.Generic;

namespace PostgreSQL_Core_App;

public partial class ViewDepartmentCourseCount
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public int? CourseCount { get; set; }
}
