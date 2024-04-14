using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class Wish
{
    public Guid Id { get; set; }
    [Required]
    public Perfume Perfume { get; set; }
    [Required]
    public User User { get; set; }
}