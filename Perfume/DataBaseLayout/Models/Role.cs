using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Name))]

public class Role: IdentityRole<Guid>
{
    
}