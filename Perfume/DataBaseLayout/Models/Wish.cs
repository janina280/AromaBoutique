using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class Wish
{
    public Guid Id { get; set; }

    public Guid PerfumeId { get; set; }

    [Required]
    public Perfume Perfume { get; set; }

    public Guid UserId { get; set; }

    [Required]
    public User User { get; set; }
}