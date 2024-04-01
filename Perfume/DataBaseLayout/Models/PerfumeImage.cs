using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class PerfumeImage
{
    public string Id { get; set; }
    public string Content { get; set; }
    public Perfume Perfume { get; set; }

}