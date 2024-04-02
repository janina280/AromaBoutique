using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class ReviewConversation
{
    public Guid Id { get; set; }
    [Required]
    public User User { get; set; }

    public string Content { get; set; }
}