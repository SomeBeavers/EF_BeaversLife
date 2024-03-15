﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PostgreSQL_Core_App;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdditionalInfo> AdditionalInfos { get; set; }

    public virtual DbSet<AdditionalTable> AdditionalTables { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<CommentTag> CommentTags { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    public virtual DbSet<OfficeAssignment> OfficeAssignments { get; set; }

    public virtual DbSet<OnlineCourse> OnlineCourses { get; set; }

    public virtual DbSet<OnsiteCourse> OnsiteCourses { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<StudentGrade> StudentGrades { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<ViewDepartmentCourseCount> ViewDepartmentCourseCounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=School;Username=postgres;Password=94719");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdditionalInfo>(entity =>
        {

            entity.Property(e => e.AdditionalInfoId).HasColumnName("AdditionalInfoID");

            entity.HasOne(d => d.StudentGrade).WithMany(p => p.AdditionalInfos)
                .HasForeignKey(d => d.StudentGradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdditionalInfo_StudentGrade");
        });

        modelBuilder.Entity<AdditionalTable>(entity =>
        {


            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.HasOne(d => d.Comment).WithMany()
                .HasForeignKey(d => d.CommentId)
                .HasConstraintName("FK_AdditionalTable_Comment");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("Comment");

            entity.HasOne(d => d.StudentGradeEnrollment).WithMany(p => p.Comments).HasForeignKey(d => d.StudentGradeEnrollmentId);
        });

        modelBuilder.Entity<CommentTag>(entity =>
        {
            entity.HasKey(e => new { e.CommentId, e.TagId });

            entity.ToTable("CommentTag");


            //entity.Property(e => e.PublicationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Comment).WithMany(p => p.CommentTags).HasForeignKey(d => d.CommentId);

            entity.HasOne(d => d.Tag).WithMany(p => p.CommentTags).HasForeignKey(d => d.TagId);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK_School.Course");

            entity.ToTable("Course");

            entity.Property(e => e.CourseId)
                .ValueGeneratedNever()
                .HasColumnName("CourseID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Department).WithMany(p => p.Courses)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Course_Department");


        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId)
                .ValueGeneratedNever()
                .HasColumnName("DepartmentID");
            entity.Property(e => e.Budget).HasColumnType("money");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.StartDate).HasColumnType("timestamp");
        });

        modelBuilder.Entity<Like>(entity =>
        {

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.HasOne(d => d.Comment).WithMany()
                .HasForeignKey(d => d.CommentId)
                .HasConstraintName("FK_Likes_Comment");
        });

        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<OfficeAssignment>(entity =>
        {
            entity.HasKey(e => e.InstructorId);

            entity.ToTable("OfficeAssignment");

            entity.Property(e => e.InstructorId)
                .ValueGeneratedNever()
                .HasColumnName("InstructorID");
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Instructor).WithOne(p => p.OfficeAssignment)
                .HasForeignKey<OfficeAssignment>(d => d.InstructorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OfficeAssignment_Person");
        });

        modelBuilder.Entity<OnlineCourse>(entity =>
        {
            entity.HasKey(e => e.CourseId);

            entity.ToTable("OnlineCourse");

            entity.Property(e => e.CourseId)
                .ValueGeneratedNever()
                .HasColumnName("CourseID");
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .HasColumnName("URL");

            entity.HasOne(d => d.Course).WithOne(p => p.OnlineCourse)
                .HasForeignKey<OnlineCourse>(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OnlineCourse_Course");
        });

        modelBuilder.Entity<OnsiteCourse>(entity =>
        {
            entity.HasKey(e => e.CourseId);

            entity.ToTable("OnsiteCourse");

            entity.Property(e => e.CourseId)
                .ValueGeneratedNever()
                .HasColumnName("CourseID");
            entity.Property(e => e.Days).HasMaxLength(50);
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.Time).HasColumnType("timestamp");

            entity.HasOne(d => d.Course).WithOne(p => p.OnsiteCourse)
                .HasForeignKey<OnsiteCourse>(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OnsiteCourse_Course");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK_School.Student");

            entity.ToTable("Person");

            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.Discriminator).HasMaxLength(50);
            entity.Property(e => e.EnrollmentDate).HasColumnType("timestamp");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.HireDate).HasColumnType("timestamp");
            entity.Property(e => e.LastName).HasMaxLength(50);

        });

        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => e.PetId).HasName("PK_dbo.Pets");

            entity.Property(e => e.PetId).HasColumnName("PetID");
        });

        modelBuilder.Entity<StudentGrade>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId);

            entity.ToTable("StudentGrade");

            entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Grade).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Course).WithMany(p => p.StudentGrades)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentGrade_Course");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentGrades)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentGrade_Student");
        });

        modelBuilder.Entity<ViewDepartmentCourseCount>(entity =>
        {

            entity.HasNoKey();
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
