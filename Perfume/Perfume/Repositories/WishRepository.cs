using DataBaseLayout.Models;
using DataBaseLayout;
using Microsoft.EntityFrameworkCore;
using Perfume.Repositories.Interfaces;

namespace Perfume.Repositories;

public class WishRepository: IWishRepository
{
    private readonly IContext _context;

    public WishRepository(IContext context)
    {
        _context = context;
    }
    public async Task<List<Wish>> GetWishListAsync()
    {
        var wish = await _context.WishList
            .Include(x=>x.Perfume)
            .Include(x=>x.User)
            .ToListAsync();

        return wish;
    }

    public async Task<Wish> GetWishAsync(Guid id)
    {
        var wish = await _context.WishList
            .Include(x => x.Perfume)
            .Include(x => x.User)
            .SingleAsync();
        return wish;
    }

    public async Task CreateWishAsync(Wish model)
    {
        await _context.WishList.AddAsync(model);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteWishAsync(Guid id)
    {
        var wish = await _context.WishList.SingleAsync(scp => scp.Id == id);
        _context.WishList.Remove(wish);

        await _context.SaveChangesAsync();
    }
}