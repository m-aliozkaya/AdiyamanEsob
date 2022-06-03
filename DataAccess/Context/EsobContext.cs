using Core.Entities.Concrete;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;

public class EsobContext : DbContext
{
    public EsobContext(DbContextOptions<EsobContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Author> Authors { get; set; }
}