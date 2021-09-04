using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class BoardConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);

            builder.Property(b => b.Name)
               .HasMaxLength(255);

            builder.Property(b => b.BoardJson)
               .HasColumnType("json");

            builder.Property(b => b.LastModified)
                .HasColumnType("timestamp")
                .HasPrecision(26, 3);

            builder.Property(b => b.Thumbnail)
                .HasColumnType("bytea");
        }
    }
}
