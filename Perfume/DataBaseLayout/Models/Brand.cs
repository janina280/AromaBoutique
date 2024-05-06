using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Name))]
public class Brand
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public byte[] Image { get; set; } = default!;
    public string ImageName { get; set; }
    public string FileName { get; set; }

    public ICollection<Perfume> Perfumes { get; set; } = default!;

}