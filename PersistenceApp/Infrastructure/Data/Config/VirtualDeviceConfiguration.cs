using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
