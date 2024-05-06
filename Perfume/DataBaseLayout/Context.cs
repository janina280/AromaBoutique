using DataBaseLayout.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout;

public class Context : IdentityDbContext<User, Role, Guid>, IContext
{
    public Context(DbContextOptions options) 
        : base(options) { }

    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Perfume> Perfumes { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<PerfumeImage> PerfumeImages { get; set; }
    public DbSet<PerfumeCategory> PerfumeCategories { get; set; }
    public DbSet<Wish> WishList { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<ReviewConversation> ReviewConversations { get; set; }
    public override DbSet<Role> Roles { get; set; }
    public DbSet<ShoppingCartPerfume> ShoppingCartPerfumes { get; set; }
    public override DbSet<User> Users { get; set; }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable(name: "Users");
        });
        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Roles");
        });
        modelBuilder.Entity<IdentityUserClaim<Guid>>(entity =>
        {
            entity.ToTable(name: "UserClaims");
        });
        modelBuilder.Entity<IdentityUserRole<Guid>>(entity =>
        {
            entity.ToTable(name: "UserRoles");
        });
        modelBuilder.Entity<IdentityUserLogin<Guid>>(entity =>
        {
                entity.ToTable(name: "UserLogins");
        });

        modelBuilder.Entity<User>().Navigation(u => u.Wishes).AutoInclude();

    }
}