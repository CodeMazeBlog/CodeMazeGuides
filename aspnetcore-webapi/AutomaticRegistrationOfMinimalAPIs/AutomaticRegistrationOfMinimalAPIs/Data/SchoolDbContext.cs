using AutomaticRegistrationOfMinimalAPIs.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomaticRegistrationOfMinimalAPIs.Data;

public class SchoolDbContext(DbContextOptions<SchoolDbContext> options)
    : DbContext(options)
{
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Teacher> Teachers { get; set; }
}
