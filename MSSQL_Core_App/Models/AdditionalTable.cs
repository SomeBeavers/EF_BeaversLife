using System;
using System.Collections.Generic;

namespace MSSQL_Core_App.Models;

public partial class AdditionalTable
{
    public int Id { get; set; }

    public int? CommentId { get; set; }

    public virtual Comment? Comment { get; set; }
}
