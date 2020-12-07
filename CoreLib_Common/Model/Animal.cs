using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CoreLib_Common.Model
{
    //[Table("Animals")]
    [Index(nameof(Name), IsUnique = true)]
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(128)] public string? Name { get; set; }
        public int Age { get; set; }

        public virtual List<Club>? Clubs { get; set; }
        public virtual ICollection<Grade>? Grades { get; set; }
        public virtual Job Job { get; set; } = null!;
        public int? JobId { get; set; }
        public virtual Food Food { get; set; } = null!;

        //public JsonDocument? Passport { get; set; }

        public override string ToString()
        {
            return $"Animal : Id = {Id} Clubs = {Clubs?.Count}";
        }
    }
}