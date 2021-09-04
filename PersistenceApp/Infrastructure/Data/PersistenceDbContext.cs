using Application.Interfaces.DataAccess;
using Entities;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public partial class PersistenceDbContext : IdentityDbContext<CoreUser, IdentityRole<int>, int>, IPersistenceDbContext
    {
        public PersistenceDbContext(DbContextOptions<PersistenceDbContext> options) : base(options)
        {
        }

        public DbSet<VirtualDevice> VirtualDevices { get; set; }
        public DbSet<Board> Boards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder
            //    .UseCamelCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasPostgresExtension("adminpack")
                .HasAnnotation("Relational:Collation", "Polish_Poland.1250");

            OnModelCreatingPartial(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
