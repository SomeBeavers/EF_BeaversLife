using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLib_Common.Model
{
    //[Table("Animals")]
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public virtual List<Club>? Clubs { get; set; }
        public virtual ICollection<Grade>? Grades { get; set; }
        public virtual Job Job { get; set; }
        public int? JobId { get; set; }

        //public JsonDocument? Passport { get; set; }

        public override string ToString()
        {
            return $"Animal : Id = {Id} Clubs = {Clubs?.Count}";
        }
    }
}