﻿
namespace CoreLib_Common;

public class NewContext : DbContext
{
    #region Tables

    public DbSet<Person>                 Persons                { get; set; } = null!;
    public DbSet<Animal>                 Animals                { get; set; } = null!;

    #endregion

    #region C-ors

    public NewContext()
    {
    }

    public NewContext(DbContextOptions<NewContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // TODO: fix connection property
            optionsBuilder.UseSqlServer(
                "Server=unit-1019\\sqlexpress;Database=BeaversLife;Trusted_Connection=True;" +
                "MultipleActiveResultSets=True");
            //optionsBuilder.UseSqlServer("Server=localhost;Database=BeaversLife;Trusted_Connection=True;" +
            //                            "MultipleActiveResultSets=True"
            //, b=> b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
            //);
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.AddInterceptors(new MySaveChangesInterceptor());

            // TODO: uncomment to use lazy loading.
            //optionsBuilder.UseLazyLoadingProxies();
            //optionsBuilder.UseLazyLoadingProxies(true);

            //optionsBuilder.UseLazyLoadingProxies(false);
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
                        c => c.HasOne(animalClub => animalClub.Club)
                              .WithMany().HasForeignKey(animalClub => animalClub.ClubId),
                        a => a.HasOne(animalClub => animalClub.Animal)
                              .WithMany().HasForeignKey(animalClub => animalClub.AnimalId),
                        j =>
                        {
                            j.Property(pt => pt.PublicationDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                            j.HasKey(t => new { t.AnimalId, t.ClubId });
                        }
                    )
            ;

        //// Many-to-many
        //modelBuilder.Entity<AdditionalInfo>()
        //            .HasMany(a => a.Clubs)
        //            .WithMany(c => c.AdditionalInfos)
        //            .UsingEntity<AdditionalInfoClub>(
        //                c => c.HasOne(additionalInfoClub => additionalInfoClub.Club)
        //                      .WithMany().HasForeignKey(additionalInfoClub => additionalInfoClub.ClubId),
        //                a => a.HasOne(additionalInfoClub => additionalInfoClub.AdditionalInfo)
        //                      .WithMany().HasForeignKey(animalClub => animalClub.AdditionalInfoId),
        //                j => { j.HasKey(t => new { t.AdditionalInfoId, t.ClubId }); }
        //            )
        //    ;

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
                j.JobId,
                j.DrawbackId
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

        //Map entity types to queries
        modelBuilder.Entity<MapToQuery>().ToSqlQuery(
            @"    select b.Id, b.Fluffiness, b.Size, ac.ClubId as ClubId from Beavers b
                              inner join AnimalClub ac on b.Id = ac.AnimalId
                              Union all
                              select cr.Id, 2, 1, ac.ClubId as ClubId  from Crows cr
                              inner join AnimalClub ac on cr.Id = ac.AnimalId
                    ");

        // Property bags
        modelBuilder.SharedTypeEntity<Dictionary<string, object>>("Category", category =>
        {
            category.IndexerProperty<int>("Id");
            category.IndexerProperty<string>("Name").IsRequired();
            category.IndexerProperty<int?>("FoodId");

            category.HasOne(typeof(Food)).WithOne() /*.HasForeignKey("Category", "FoodId")*/;
        });

        modelBuilder.SharedTypeEntity<Dictionary<string, object>>("Product", product =>
        {
            product.IndexerProperty<int>("Id");
            product.IndexerProperty<string>("Name").IsRequired();
            product.IndexerProperty<int?>("CategoryId");

            product.HasOne("Category", null).WithMany();
        });

        // Required 1:1 dependents
        modelBuilder.Entity<Drawback>(drawback =>
        {
            drawback.OwnsOne(d => d.Consequence,
                cons => { cons.Property(c => c.Name).IsRequired(); });
            drawback.Navigation(d => d.Consequence).IsRequired();
        });

        // Table-valued functions
        modelBuilder.Entity(typeof(AnimalLocation)).HasNoKey();

        // Table splitting
        modelBuilder.Entity<AdditionalInfoDetailed>(additionalInfoSmall =>
        {
            additionalInfoSmall.ToTable("AdditionalInfos");
        });
        modelBuilder.Entity<AdditionalInfo>(additionalInfo =>
        {
            additionalInfo.ToTable("AdditionalInfos");

            additionalInfo.HasOne(o => o.AdditionalInfoDetailed).WithOne().HasForeignKey<AdditionalInfoDetailed>(o => o.Id);
        });
    }
}
