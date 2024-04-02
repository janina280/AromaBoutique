using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

[PrimaryKey(nameof(Name))]

public class Role
{
    public string Name { get; set; }
    public ICollection<User> Users { get; set; }
    [Required]
    public virtual ICollection<Feature> Features { get; set; }
}