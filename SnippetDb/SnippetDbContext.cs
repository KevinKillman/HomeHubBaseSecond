using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SnippetDb.Tables;

namespace SnippetDb
{
  public class SnippetDbContext : IdentityDbContext
  {
    public DbSet<Snippet> Snippets { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public SnippetDbContext(DbContextOptions<SnippetDbContext> options)
        : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      //var connectionStr = "Data Source=DESKTOP-VAUEP5A;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
      //optionsBuilder.UseSqlServer(connectionStr, assembly => assembly.MigrationsAssembly("SnippetDb"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<Snippet>().HasData(new Snippet()
      {
        Id = 1,
        Content = "Example Content",
        Title = "Title",
        Subject = "Subject"
      });
      modelBuilder.Entity<Tag>().HasData(new Tag()
      {
        Id = 1,
        Name = "Test Tag",
      });
    }
  }
}