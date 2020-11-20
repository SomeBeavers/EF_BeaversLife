﻿using System.Collections.Generic;
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
        public NotMappedText LocalizedText { get; set; }

        public virtual ICollection<Animal>? Animals { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Drawback>? Drawbacks { get; set; }

        public override string ToString()
        {
            return $@"Club: Id = {Id} Title = {Title}";
        }
    }

    [NotMapped]
    public class NotMappedText
    {
        public string LocalizedText { get; set; }
    }
}