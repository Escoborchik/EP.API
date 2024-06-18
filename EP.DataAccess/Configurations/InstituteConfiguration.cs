using EP.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EP.DataAccess.Configurations
{
    public class InstituteConfiguration : IEntityTypeConfiguration<InstituteEntity>
    {
        public void Configure(EntityTypeBuilder<InstituteEntity> builder)
        {
            builder.HasData(
                new InstituteEntity { Uuid = Guid.NewGuid(), Title = "Институт радиоэлектроники и информационных технологий - РтФ" },
                new InstituteEntity { Uuid = Guid.NewGuid(), Title = "Институт естественных наук и математики" },
                new InstituteEntity { Uuid = Guid.NewGuid(), Title = "Физико-технологический институт" });
        }
    }
}
