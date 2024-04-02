using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Name))]
public class Brand
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; } = default!;
    public ICollection<Perfume> Perfumes { get; set; } = default!;

}