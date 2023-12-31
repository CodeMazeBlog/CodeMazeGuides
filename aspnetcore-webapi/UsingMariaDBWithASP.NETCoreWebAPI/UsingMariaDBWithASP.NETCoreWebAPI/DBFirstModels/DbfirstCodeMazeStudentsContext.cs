using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace UsingMariaDBWithASP.NETCoreWebAPI.DBFirstModels;

public partial class DbfirstCodeMazeStudentsContext : DbContext
{
    public DbfirstCodeMazeStudentsContext()
    {
    }

    public DbfirstCodeMazeStudentsContext(DbContextOptions<DbfirstCodeMazeStudentsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=DBFirstCodeMazeStudents;user=root;password=cjaynjoku", Microsoft.EntityFrameworkCore.ServerVersion.Parse("11.2.2-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("courses");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreditUnit).HasColumnType("int(11)");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("students");

            entity.Property(e => e.Id).HasColumnType("int(11)");

            entity.HasMany(d => d.Courses).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "Studentcourse",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseId")
                        .HasConstraintName("studentcourse_ibfk_1"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .HasConstraintName("studentcourse_ibfk_2"),
                    j =>
                    {
                        j.HasKey("StudentId", "CourseId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("studentcourse");
                        j.HasIndex(new[] { "CourseId" }, "CourseId");
                        j.IndexerProperty<int>("StudentId").HasColumnType("int(11)");
                        j.IndexerProperty<int>("CourseId").HasColumnType("int(11)");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
