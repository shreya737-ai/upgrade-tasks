using Microsoft.EntityFrameworkCore;
using week9_task1.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<UserInfo> Users { get; set; }
}
