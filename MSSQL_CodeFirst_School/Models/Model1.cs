using System.Data.Entity;

namespace MSSQL_CodeFirst_School.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<C__EFMigrationsHistory> C__EFMigrationsHistory { get; set; }
        public virtual DbSet<AdditionalInfo> AdditionalInfos { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentTag> CommentTags { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public virtual DbSet<OnlineCourse> OnlineCourses { get; set; }
        public virtual DbSet<OnsiteCourse> OnsiteCourses { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<StudentGrade> StudentGrades { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<AdditionalTable> AdditionalTables { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        //public virtual DbSet<NickName> NickNames { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasOptional(e => e.Comment1)
                .WithRequired(e => e.Comment2);

            modelBuilder.Entity<Course>()
                .HasOptional(e => e.OnlineCourse)
                .WithRequired(e => e.Course);

            modelBuilder.Entity<Course>()
                .HasOptional(e => e.OnsiteCourse)
                .WithRequired(e => e.Course);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.StudentGrades)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.People)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("CourseInstructor").MapLeftKey("CourseID").MapRightKey("PersonID"));

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Pets)
                .WithMany(e => e.People);

            modelBuilder.Entity<Department>()
                .Property(e => e.Budget)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OfficeAssignment>()
                .Property(e => e.Timestamp)
                .IsFixedLength();

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.OfficeAssignment)
                .WithRequired(e => e.Person);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.StudentGrades)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.StudentID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StudentGrade>()
                .Property(e => e.Grade)
                .HasPrecision(3, 2);

            modelBuilder.Entity<StudentGrade>()
                .HasMany(e => e.AdditionalInfos)
                .WithRequired(e => e.StudentGrade)
                .HasForeignKey(e => e.StudentGradeId)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Pet>()
            //    .HasRequired(t => t.NickName)
            //    .WithRequiredPrincipal(t => t.Pet);
        }
    }
}
