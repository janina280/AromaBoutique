using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Name))]

public class Delivery
{
    public string Name { get; set; }
    public virtual ICollection<Perfume> Perfumes { get; set; }
}