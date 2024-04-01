using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class Promotion
{
    public string Id { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
}