using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout;

public class Context : DbContext, IContext
{
    public Context(DbContextOptions options) 
        : base(options) { }

    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Perfume> Perfumes { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<PerfumeImage> PerfumeImages { get; set; }
    public DbSet<PerfumeCategory> PerfumeCategories { get; set; }
    public DbSet<Wish> WishList { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<ReviewConversation> ReviewConversations { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<ShoppingCartPerfume> ShoppingCartPerfumes { get; set; }
    public DbSet<User> Users { get; set; }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}