using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLib_Common.Model
{
    public class Club
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Animal>? Animals { get; set; }
        public override string ToString()
        {
            return $@"Club: Id = {this.Id} Animals = {Animals?.Count}";
        }

        public NotMappedText LocalizedText { get; set; }
    }

    [NotMapped]
    public class NotMappedText
    {
        public string LocalizedText { get; set; }
    }
}