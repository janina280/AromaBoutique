using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class ReviewConversation
{
    public string Id { get; set; }
    public Review Review { get; set; }

    public User User { get; set; }

    public string Content { get; set; }
}