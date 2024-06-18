using EP.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EP.DataAccess.Configurations
{
    public class ModuleConfiguration : IEntityTypeConfiguration<ModuleEntity>
    {        
        public void Configure(EntityTypeBuilder<ModuleEntity> builder)
        {
            builder
            .HasMany(m => m.EducationPrograms)
            .WithMany(p => p.Modules);
        }
    }
}
