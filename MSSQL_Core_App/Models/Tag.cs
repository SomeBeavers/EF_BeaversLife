using System;
using System.Collections.Generic;

namespace MSSQL_Core_App.Models;

public partial class Tag
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public virtual ICollection<CommentTag> CommentTags { get; set; } = new List<CommentTag>();
}
