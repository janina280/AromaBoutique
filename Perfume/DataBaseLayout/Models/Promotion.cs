using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class Promotion
{
    public Guid Id { get; set; }
    public string Image { get; set; } = default!;
    public string Description { get; set; }
}