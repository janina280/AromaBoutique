using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class ShoppingCartPerfume
{
    public Guid Id { get; set; }
    [Required]
    public User User { get; set; }
    [Required]
    public Perfume Perfume { get; set; }

    //todo: save perfume quantity
}