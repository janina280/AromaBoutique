using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout;

public interface IContext
{
    DbSet<Promotion> Promotions { get; set; }
    DbSet<Brand> Brands { get; set; }
    DbSet<PerfumeCategory> PerfumeCategories { get; set; }
    DbSet<Perfume> Perfumes { get; set; }
    DbSet<Delivery> Deliveries { get; set; }
    DbSet<Feature> Features { get; set; }
    DbSet<PerfumeImage> PerfumeImages { get; set; }
    DbSet<Wish> WishList { get; set; }
    DbSet<Review> Reviews { get; set; }
    DbSet<ReviewConversation> ReviewConversations { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<ShoppingCartPerfume> ShoppingCartPerfumes { get; set; }
    DbSet<User> Users { get; set; }

}