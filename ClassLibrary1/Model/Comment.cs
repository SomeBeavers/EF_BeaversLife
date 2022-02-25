using System;
using System.Collections.Generic;

namespace ClassLibrary1.Model
{
    public partial class Comment
    {
        public Comment()
        {
            CommentTags = new HashSet<CommentTag>();
        }

        public int CommentId { get; set; }
        public int? StudentGradeEnrollmentId { get; set; }

        public virtual StudentGrade? StudentGradeEnrollment { get; set; }
        public virtual ICollection<CommentTag> CommentTags { get; set; }

    }
}
