using EP.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EP.DataAccess.Configurations
{
    public class EducationProgramConfiguration : IEntityTypeConfiguration<EducationProgramEntity>
    {
        public void Configure(EntityTypeBuilder<EducationProgramEntity> builder)
        {
            builder.HasOne(p => p.Head);

            builder.HasOne(p => p.Institute);
          
        }
    }
}
