using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ViewBasedAuthorization.Models;

namespace ViewBasedAuthorization.Data;

public class DocumentContext : IdentityDbContext<IdentityUser>
{
    public DocumentContext(DbContextOptions<DocumentContext> options) : base(options) { }

    public DbSet<Document> Documents { get; set; }
}
