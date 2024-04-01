using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;

[PrimaryKey(nameof(Id))]
public class Wish
{
    public string Id { get; set; }
    public Perfume Perfume { get; set; }
    public User User { get; set; }
}