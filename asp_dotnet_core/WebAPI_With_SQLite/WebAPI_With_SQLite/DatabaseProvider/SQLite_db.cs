using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI_With_SQLite.DataModel;

namespace WebAPI_With_SQLite.DatabaseProvider
{
    public class SQLite_db : DbContext
    {
        public SQLite_db(DbContextOptions<SQLite_db> options) : base(options)
        {
            // Applies any pending migrations for the context to the database.
            // Will create the database if it does not already exist.
            Database.Migrate();
        }
        // Override this method to further configure the model that was discovered
        // by convention from the entity types exposed in DbSet<TEntity> properties
        // on your derived context. The resulting model may be cached and re-used for
        // subsequent instances of your derived context.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("students").Property(e => e.id).ValueGeneratedOnAdd();
        }
        public DbSet<Student> students { get; set; }
    }
}
