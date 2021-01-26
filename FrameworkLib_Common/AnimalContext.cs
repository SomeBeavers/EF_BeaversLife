using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FrameworkLib_Common.Model;

namespace FrameworkLib_Common
{
    public class AnimalContext: DbContext
    {
        #region Tables

        //public DbSet<Animal> Animals { get; set; } = null!;
        public DbSet<Beaver> Beavers { get; set; } = null!;
        //public DbSet<Crow> Crows { get; set; } = null!;
        //public DbSet<Deer> Deers { get; set; } = null!;
        //public DbSet<Club> Clubs { get; set; } = null!;
        //public DbSet<Grade> Grades { get; set; } = null!;
        //public DbSet<Job> Jobs { get; set; } = null!;
        //public DbSet<Drawback> Drawbacks { get; set; } = null!;
        //public DbSet<JobDrawback> JobDrawbacks { get; set; } = null!;
        //public DbSet<Food> Food { get; set; } = null!;
        //public DbSet<NormalFood> NormalFood { get; set; } = null!;
        //public DbSet<VeganFood> VeganFood { get; set; } = null!;

        //public DbSet<MapToQuery> MapToQuery { get; set; } = null!;

        //// Property bags
        //public DbSet<Dictionary<string, object>> Products => Set<Dictionary<string, object>>("Product");
        //public DbSet<Dictionary<string, object>> Categories => Set<Dictionary<string, object>>("Category");

        #endregion

        #region C-ors

        public AnimalContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
