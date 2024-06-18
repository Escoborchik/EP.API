using EP.DataAccess.Configurations;
using EP.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EP.DataAccess
{
    public class EPDbContext : DbContext
    {
        public DbSet<EducationProgramEntity> EducationPrograms { get; set; }

        public DbSet<ModuleEntity> Modules { get; set; }

        public DbSet<HeadEntity> Heads { get; set; }

        public DbSet<InstituteEntity> Institutes { get; set; }

        public DbSet<UserEntity> Users { get; set; }
        public EPDbContext(DbContextOptions<EPDbContext> options)
        : base(options)
        {    
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EducationProgramConfiguration());

            modelBuilder.ApplyConfiguration(new HeadConfiguration());

            modelBuilder.ApplyConfiguration(new InstituteConfiguration());

            modelBuilder.ApplyConfiguration(new ModuleConfiguration());

        }
    }
}