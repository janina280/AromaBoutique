using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Name))]

public class Feature
{
    public string Name { get; set; }
    public string HTMLFlag { get; set; }
    public virtual ICollection<Role> Roles { get; set; }
}