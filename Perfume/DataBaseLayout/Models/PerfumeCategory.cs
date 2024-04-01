using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Name))]
public class PerfumeCategory
{
    public string Name { get; set; }
    public ICollection<Perfume> Perfumes { get; } = new List<Perfume>();
}