using System;
using System.Collections.Generic;

namespace ClassLibrary1.Model
{
    public partial class Tag
    {
        public Tag()
        {
            CommentTags = new HashSet<CommentTag>();
        }

        public int Id { get; set; }
        public string? Text { get; set; }

        public virtual ICollection<CommentTag> CommentTags { get; set; }
    }
    public partial class Tag2
    {
        public Tag2()
        {
            CommentTags = new HashSet<CommentTag>();
        }

        public int Id { get; set; }
        public string? Text { get; set; }

        public virtual ICollection<CommentTag> CommentTags { get; set; }
    }
}
