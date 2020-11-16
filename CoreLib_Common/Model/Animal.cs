using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

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

        //public JsonDocument? Passport { get; set; }

        public override string ToString()
        {

            return $"Animal : Id = {this.Id} Clubs = {Clubs?.Count}";
        }
    }
}