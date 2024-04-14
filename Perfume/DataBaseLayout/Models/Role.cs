using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Name))]

public class Role
{
    public string Name { get; set; }
    public ICollection<User> Users { get; set; }
    [Required]
    public virtual ICollection<Feature> Features { get; set; }
}