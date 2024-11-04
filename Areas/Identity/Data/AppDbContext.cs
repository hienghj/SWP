using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Report> Reports { get; set; }
    public DbSet<Statistics> Statistics { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Complaint> Complaints { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
