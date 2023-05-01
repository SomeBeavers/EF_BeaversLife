using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSSQL_CodeFirst_School.Models
{
    [Table("Person")]
    public partial class Person
    {
        private ICollection<Pet> _pets;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            StudentGrades = new HashSet<StudentGrade>();
            Courses = new HashSet<Course>();
        }

        public int PersonID { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        public DateTime? HireDate { get; set; }

        public DateTime? EnrollmentDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Discriminator { get; set; }

        public virtual OfficeAssignment OfficeAssignment { get; set; }

        //public virtual OnlinePerson OnlinePerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Pet> Pets
        {
            get => _pets;
            set => _pets = value;
        }
    }

    //public class NickName
    //{
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int NickNameID { get; set; }

    //    public string Name { get; set; }

    //    public virtual Pet Pet { get; set; }
    //}
}
