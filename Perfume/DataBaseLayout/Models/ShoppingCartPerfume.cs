using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class ShoppingCartPerfume
{
    public string Id { get; set; }
    public User User { get; set; }
    public Perfume Perfume { get; set; }
}