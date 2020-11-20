using System;
using CoreLib_Common.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CoreLib_Common
{
    public class AnimalContext: DbContext
    {
        #region Tables

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Beaver> Beavers { get; set; }
        public DbSet<Crow> Crows { get; set; }
        public DbSet<Deer> Deers { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Drawback> Drawbacks { get; set; }
        public DbSet<JobDrawback> JobDrawbacks { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<NormalFood> NormalFood { get; set; }
        public DbSet<VeganFood> VeganFood { get; set; }

        #endregion

        #region C-ors

        public AnimalContext()
        {
        }

        public AnimalContext(DbContextOptions<AnimalContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // TODO: fix connection property
                optionsBuilder.UseSqlServer("Server=localhost;Database=BeaversLife;Trusted_Connection=True;"+
                                            "MultipleActiveResultSets=True");
                optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            }
        }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TPT
            modelBuilder.Entity<Animal>().ToTable("Animals");
            modelBuilder.Entity<Beaver>().ToTable("Beavers");
            modelBuilder.Entity<Crow>().ToTable("Crows");
            modelBuilder.Entity<Deer>().ToTable("Deers");

            // Many-to-many
            modelBuilder.Entity<Animal>()
                        .HasMany(a => a.Clubs)
                        .WithMany(c => c.Animals)
                        .UsingEntity<AnimalClub>(
                            c => c.HasOne(c => c.Club)
                                  .WithMany().HasForeignKey(c => c.ClubId),
                            a => a.HasOne(a => a.Animal)
                                  .WithMany().HasForeignKey(a => a.AnimalId),
                            j =>
                            {
                                j.Property(pt => pt.PublicationDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                                j.HasKey(t => new {t.AnimalId, t.ClubId});
                            }
                        )
                ;

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.TheGrade)
                      .HasColumnType("decimal(3, 2)")
                      .HasAnnotation("Relational:ColumnType", "decimal(3, 2)");
            });

            // Many-to-many old style
            modelBuilder.Entity<JobDrawback>(entity =>
            {
                entity.HasKey(j => new
                {
                    j.JobId, j.DrawbackId
                });

                entity.HasOne(jd => jd.Job)
                      .WithMany(j => j.JobDrawbacks)
                      .HasForeignKey(x => x.JobId)
                      .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(jd => jd.Drawback)
                      .WithMany(d => d.JobDrawbacks)
                      .HasForeignKey(x => x.DrawbackId)
                      .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
