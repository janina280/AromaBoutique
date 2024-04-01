using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Name))]

public class Feature
{
    public int Name { get; set; }
    public string HTMLFlag { get; set; }
    public virtual ICollection<Role> Roles { get; set; }
}