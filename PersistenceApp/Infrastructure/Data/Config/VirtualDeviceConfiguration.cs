using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class VirtualDeviceConfiguration : IEntityTypeConfiguration<VirtualDevice>
    {
        public void Configure(EntityTypeBuilder<VirtualDevice> builder)
        {
            builder.Property(b => b.Name)
                .HasMaxLength(64);
        }
    }
}
