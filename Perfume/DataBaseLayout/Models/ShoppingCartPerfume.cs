using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class ShoppingCartPerfume
{
    public Guid Id { get; set; }
    [Required]
    public User User { get; set; }
    public Guid UserId { get; set; } 
    [Required]
    public Perfume Perfume { get; set; }
    public Guid PerfumeId { get; set; }

    public int Quantity { get; set; } = 1;
}