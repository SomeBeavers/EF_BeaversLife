using System;
using System.Collections.Generic;

namespace ClassLibrary1.Model
{
    public partial class CommentTag
    {
        public int CommentId { get; set; }
        public int TagId { get; set; }
        public DateTime PublicationDate { get; set; }

        public virtual Comment Comment { get; set; } = null!;
        public virtual Tag Tag { get; set; } = null!;
    }
}
