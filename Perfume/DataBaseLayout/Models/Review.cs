using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class Review
{
    public string Id { get; set; }
    public string Content { get; set; }
    public User User { get; set;}
    public Perfume Perfume { get; set; }

    public ICollection<ReviewConversation> ReviewConversations { get; set; }
}