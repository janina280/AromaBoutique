using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;

[PrimaryKey(nameof(Name))]

public class Role
{
    public string Name { get; set; }
    public ICollection<User> Users { get; set; }
    public virtual ICollection<Feature> Features { get; set; }
}