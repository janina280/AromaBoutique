using Microsoft.AspNetCore.Identity;

namespace DataBaseLayout.Models;

public class User: IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte[] ProfileImage { get; set; }
    public string FileName { get; set; }
    public string ImageName { get; set; }

    public ICollection<ReviewConversation> ReviewConversations { get; set; }

    public ICollection<Review> Reviews { get; set; } = new List<Review>();

    public ICollection<ShoppingCartPerfume> ShoppingCartPerfumes { get; set; } = new List<ShoppingCartPerfume>();

    public ICollection<Wish> Wishes { get; set; } = new List<Wish>();

}