using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class Perfume
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public double Rating { get; set; } = 0;
    public int Stock { get; set; }
    public int Price { get; set; }
    public string Currency { get; set; }
    public double RatingAppearance { get; set; } = 0;
    public double RatingIntension { get; set; } = 0;
    public double RatingPersistence { get; set; } = 0;
    public string ProfileImage { get; set; } = default!;

    [Required]
    public Brand Brand { get; set; }
    [Required]
    public PerfumeCategory PerfumeCategory { get; set; }

    public ICollection<Wish> Wishes { get; set; }

    public ICollection<Review> Reviews { get; set; }

    public ICollection<ShoppingCartPerfume> ShoppingCartPerfumes { get; set; }

    public ICollection<PerfumeImage> PerfumeImages { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; }


}