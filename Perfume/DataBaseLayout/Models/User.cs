using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Phone { get; set; }
    [Required]
    public Role Role { get; set; }

    public ICollection<ReviewConversation> ReviewConversations { get; set; }

    public ICollection<Review> Reviews { get; set; }

    public ICollection<ShoppingCartPerfume> ShoppingCartPerfumes { get; set; }

    public ICollection<Wish> Wishes { get; set; }

}