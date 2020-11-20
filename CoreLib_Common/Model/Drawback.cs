﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLib_Common.Model
{
    public class Drawback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<JobDrawback>? JobDrawbacks { get; set; }
        public virtual ICollection<Food>? Foods { get; set; }
        public virtual ICollection<Club>? Clubs { get; set; }

        public override string ToString()
        {
            return $"Drawback : Id = {Id} Title = {Title}";
        }
    }
}