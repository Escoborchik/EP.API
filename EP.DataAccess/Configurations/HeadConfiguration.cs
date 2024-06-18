using EP.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EP.DataAccess.Configurations
{
    public class HeadConfiguration : IEntityTypeConfiguration<HeadEntity>
    {
        public void Configure(EntityTypeBuilder<HeadEntity> builder)
        {
            builder.HasData(
                new HeadEntity { Uuid = Guid.NewGuid(), FullName = "Обухов Олег Владимирович" },
                new HeadEntity { Uuid = Guid.NewGuid(), FullName = "Климов Дмитрий Александрович" },
                new HeadEntity { Uuid = Guid.NewGuid(), FullName = "Обабков Илья Николаевич" });
        }
    }
}
