using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;

[PrimaryKey(nameof(Name))]

public class Delivery
{
    public string Name { get; set; }
    public virtual ICollection<Perfume> Perfumes { get; set; }
}