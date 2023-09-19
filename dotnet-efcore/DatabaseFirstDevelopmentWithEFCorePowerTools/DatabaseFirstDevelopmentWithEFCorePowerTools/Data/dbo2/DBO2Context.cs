using Microsoft.EntityFrameworkCore;
using EFCorePowerToolsExample.Models;

namespace EFCorePowerToolsExample.Data
{
    public partial class DBO2Context : DbContext
    {
        public virtual DbSet<Movies> Movies { get; set; }

        public DBO2Context()
        {
        }

        public DBO2Context(DbContextOptions<DBO2Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movies>(entity =>
            {
                entity.ToTable("Movies", "dbo2");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
