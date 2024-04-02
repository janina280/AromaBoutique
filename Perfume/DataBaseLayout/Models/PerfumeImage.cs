using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class PerfumeImage
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public Perfume Perfume { get; set; }

}