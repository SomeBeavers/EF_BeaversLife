using System;
using System.Collections.Generic;

namespace ClassLibrary1.Model
{
    public partial class Like
    {
        public int Id { get; set; }
        public int? CommentId { get; set; }

        public virtual Comment? Comment { get; set; }
    }
}
