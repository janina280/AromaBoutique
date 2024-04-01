using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class Perfume
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Rating { get; set; }
    public int Stock { get; set; }
    public double Price { get; set; }
    public double RatingAppearance { get; set; }
    public double RatingIntension { get; set; }
    public double RatingPersistence { get; set; }
    public string ProfileImage { get; set; }

    [Required]
    public Brand Brand { get; set; }
    [Required]
    public PerfumeCategory PerfumeCategory { get; set; }

    [Required]
    public ICollection<Wish> Wishes { get; set; }

    public ICollection<Review> Reviews { get; set; }

    public ICollection<ShoppingCartPerfume> ShoppingCartPerfumes { get; set; }

    public ICollection<PerfumeImage> PerfumeImages { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; }


}