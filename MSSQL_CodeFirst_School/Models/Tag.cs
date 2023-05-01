using System.Collections.Generic;

namespace MSSQL_CodeFirst_School.Models
{
    public partial class Tag
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tag()
        {
            CommentTags = new HashSet<CommentTag>();
        }

        public int Id { get; set; }

        public string Text { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentTag> CommentTags { get; set; }
    }
}
