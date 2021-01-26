using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrameworkLib_Common.Model
{
    public class Drawback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public virtual ICollection<JobDrawback>? JobDrawbacks { get; set; }
        public virtual ICollection<Food>? Foods { get; set; }
        public virtual ICollection<Club>? Clubs { get; set; }
        public virtual Consequence Consequence { get; set; } = null!;

        public override string ToString()
        {
            return $"Drawback : Id = {Id} Title = {Title}";
        }
    }
}