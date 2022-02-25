using System;
using System.Collections.Generic;

namespace ClassLibrary1.Model
{
    public partial class ViewDepartmentCourseCount
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int? CourseCount { get; set; }
    }
}
