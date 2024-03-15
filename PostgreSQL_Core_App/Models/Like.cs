using System;
using System.Collections.Generic;

namespace PostgreSQL_Core_App;

public partial class Like
{
    public int Id { get; set; }

    public int? CommentId { get; set; }

    public virtual Comment? Comment { get; set; }
}
