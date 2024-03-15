using EFCorePowerToolsExample.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCorePowerToolsExample.Data;

public partial class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Authors> Authors { get; set; }

    public virtual DbSet<BookDetails> BookDetails { get; set; }

    public virtual DbSet<Books> Books { get; set; }

    public virtual DbSet<BooksCategories> BooksCategories { get; set; }

    public virtual DbSet<Categories> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Authors>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC27AAED307D");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BookDetails>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("BookDetails");

            entity.Property(e => e.AuthorFirstName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AuthorLastName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.BookName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Books>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC27F766A61A");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__Books__AuthorID__4316F928");
        });

        modelBuilder.Entity<BooksCategories>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books_Ca__3214EC2799E00990");

            entity.ToTable("Books_Categories");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

            entity.HasOne(d => d.Book).WithMany(p => p.BooksCategories)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__Books_Cat__BookI__45F365D3");

            entity.HasOne(d => d.Category).WithMany(p => p.BooksCategories)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Books_Cat__Categ__46E78A0C");
        });

        modelBuilder.Entity<Categories>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC27622D3E67");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingGeneratedProcedures(modelBuilder);
        OnModelCreatingGeneratedFunctions(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
