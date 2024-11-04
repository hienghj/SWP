using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SWP_Project.Areas.Identity.Data;
using SWP_Project.Models;
namespace SWP_Project.Datas;
public class ApplicationContext : IdentityDbContext<User> // Hoặc DbContext nếu bạn không dùng Identity
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) { }

    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Event> Events { get; set; } // Nếu bạn có thực thể Event

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Gọi phương thức cơ sở

        modelBuilder.Entity<Ticket>(b =>
        {
            b.Property(t => t.Id).ValueGeneratedOnAdd();
            b.HasKey(t => t.Id);
            // Các cấu hình khác nếu cần
        });

        modelBuilder.Entity<Event>(b =>
        {
            b.Property(e => e.Id).ValueGeneratedOnAdd();
            b.HasKey(e => e.Id);
            // Các cấu hình khác nếu cần
        });

        modelBuilder.Entity<User>(b =>
        {
            b.Property(u => u.Id).HasColumnType("nvarchar(450)");
            b.HasKey(u => u.Id);
            // Các cấu hình khác nếu cần
        });

        ConfigureIdentityModel(modelBuilder);
    }

    private void ConfigureIdentityModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole>(b =>
        {
            b.Property(r => r.Id).HasColumnType("nvarchar(450)");
            b.HasKey(r => r.Id);
            b.HasIndex(r => r.NormalizedName).IsUnique()
                .HasDatabaseName("RoleNameIndex")
                .HasFilter("[NormalizedName] IS NOT NULL");
            b.ToTable("AspNetRoles");
        });

        modelBuilder.Entity<IdentityUserClaim<string>>(b =>
        {
            b.Property(c => c.Id).ValueGeneratedOnAdd();
            b.HasKey(c => c.Id);
            b.HasIndex(c => c.UserId);
            b.ToTable("AspNetUserClaims");
        });

        modelBuilder.Entity<IdentityUserLogin<string>>(b =>
        {
            b.HasKey(l => new { l.LoginProvider, l.ProviderKey });
            b.HasIndex(l => l.UserId);
            b.ToTable("AspNetUserLogins");
        });

        modelBuilder.Entity<IdentityUserRole<string>>(b =>
        {
            b.HasKey(ur => new { ur.UserId, ur.RoleId });
            b.HasIndex(ur => ur.RoleId);
            b.ToTable("AspNetUserRoles");
        });

        modelBuilder.Entity<IdentityUserToken<string>>(b =>
        {
            b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
            b.ToTable("AspNetUserTokens");
        });
    }
}
