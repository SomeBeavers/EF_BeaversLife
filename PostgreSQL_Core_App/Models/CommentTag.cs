using System;
using System.Collections.Generic;

namespace PostgreSQL_Core_App;

public partial class CommentTag
{
    public int CommentId { get; set; }

    public int TagId { get; set; }

    public DateTime PublicationDate { get; set; }

    public virtual Comment Comment { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
