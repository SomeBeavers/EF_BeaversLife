using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSSQL_CodeFirst_School.Models
{
    public class Pet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PetID { get; set; }

        public virtual ICollection<Person> People { get; set; }
        public string Name { get; set; }
        
        //public virtual NickName NickName { get; set; }
    }
}