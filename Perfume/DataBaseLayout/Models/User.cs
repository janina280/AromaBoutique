using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;

[PrimaryKey(nameof(Id))]
public class User
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public Role Role { get; set; }

    public ICollection<ReviewConversation> ReviewConversations { get; set; }

    public ICollection<Review> Reviews { get; set; }

    public ICollection<ShoppingCartPerfume> ShoppingCartPerfumes { get; set; }

    public ICollection<Wish> Wishes { get; set; }

}