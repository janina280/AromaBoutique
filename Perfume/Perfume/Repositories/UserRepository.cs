using DataBaseLayout.Models;
using DataBaseLayout;
using Microsoft.EntityFrameworkCore;
using Perfume.Repositories.Interfaces;

namespace Perfume.Repositories;

public class UserRepository: IUserRepository
{
    private readonly IContext _context;

    public UserRepository(IContext context)
    {
        _context = context;
    }
    public async Task<List<User>> GetUsersAsync()
    {
        var user = await _context.Users.Include(x=>x.Role)
            .Include(x=>x.Reviews)
            .Include(x=>x.ReviewConversations)
            .Include(x=>x.ShoppingCartPerfumes)
            .Include(x=>x.Wishes)
            .ToListAsync();

        return user;
    }

    public async Task<User> GetUserAsync(Guid id)
    {
        var user = await _context.Users
            .Include(x => x.Role)
            .Include(x => x.Reviews)
            .Include(x => x.ReviewConversations)
            .Include(x => x.ShoppingCartPerfumes)
            .Include(x => x.Wishes)
            .SingleAsync();
        return user;
    }

    public async Task CreateUserAsync(User model)
    {
        await _context.Users.AddAsync(model);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(Guid id)
    {
        var user = await _context.Users.SingleAsync(scp => scp.Id == id);
        _context.Users.Remove(user);

        await _context.SaveChangesAsync();
    }
}