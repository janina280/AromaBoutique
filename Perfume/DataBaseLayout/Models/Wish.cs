using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

[PrimaryKey(nameof(Id))]
public class Wish
{
    public Guid Id { get; set; }
    [Required]
    public Perfume Perfume { get; set; }
    [Required]
    public User User { get; set; }
}