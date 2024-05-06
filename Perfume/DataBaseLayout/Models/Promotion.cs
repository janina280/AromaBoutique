using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class Promotion
{
    public Guid Id { get; set; }
    public byte[] Image { get; set; } = default!;
    public string ImageName { get; set; }
    public string FileName { get; set; }
    public string Description { get; set; }
}