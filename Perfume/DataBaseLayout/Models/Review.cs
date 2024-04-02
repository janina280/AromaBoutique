using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class Review
{
    public Guid Id { get; set; }
    public string? Content { get; set; }
    [Required]
    public User User { get; set; }
    [Required]
    public Perfume Perfume { get; set; }

    public ICollection<ReviewConversation> ReviewConversations { get; set; }
}