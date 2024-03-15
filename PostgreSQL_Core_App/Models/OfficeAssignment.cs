using System;
using System.Collections.Generic;

namespace PostgreSQL_Core_App;

public partial class OfficeAssignment
{
    public int InstructorId { get; set; }

    public string Location { get; set; } = null!;

    public byte[] Timestamp { get; set; } = null!;

    public virtual Person Instructor { get; set; } = null!;
}
