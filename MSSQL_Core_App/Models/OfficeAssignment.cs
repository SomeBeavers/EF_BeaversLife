﻿using System;
using System.Collections.Generic;

namespace MSSQL_Core_App.Models;

public partial class OfficeAssignment
{
    public int InstructorId { get; set; }

    public string Location { get; set; } = null!;

    public byte[] Timestamp { get; set; } = null!;

    public virtual Person Instructor { get; set; } = null!;
}
