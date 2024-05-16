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
            .Include(x => x.Perfume.Brand)
            .Include(x => x.Perfume.PerfumeCategory)
            .Include(x => x.Perfume.Wishes)
            .Include(x => x.Perfume.Reviews)
            .Include(x => x.Perfume.ShoppingCartPerfumes)
            .Include(x => x.Perfume.PerfumeImages)
            .Include(x => x.Perfume.Deliveries)
            .ToListAsync();

        return wish;
    }

    public async  Task<List<Wish>> GetWishListByUserIdAsync(Guid userId)
    {
        var wish = await _context.WishList
            .Include(x => x.Perfume)
            .Include(x => x.User)
            .Include(x => x.Perfume.Brand)
            .Include(x => x.Perfume.PerfumeCategory)
            .Include(x => x.Perfume.Wishes)
            .Include(x => x.Perfume.Reviews)
            .Include(x => x.Perfume.ShoppingCartPerfumes)
            .Include(x => x.Perfume.PerfumeImages)
            .Include(x => x.Perfume.Deliveries)
            .Where(scp => scp.UserId == userId)
            .ToListAsync();

        return wish;
    }

    public async Task<Wish> GetWishAsync(Guid id)
    {
        var wish = await _context.WishList
            .Include(x => x.Perfume)
            .Include(x => x.User)
            .Include(x => x.Perfume.Brand)
            .Include(x => x.Perfume.PerfumeCategory)
            .Include(x => x.Perfume.Wishes)
            .Include(x => x.Perfume.Reviews)
            .Include(x => x.Perfume.ShoppingCartPerfumes)
            .Include(x => x.Perfume.PerfumeImages)
            .Include(x => x.Perfume.Deliveries)
            .SingleAsync(w => w.Id == id);
        return wish;
    }

    public async Task CreateWishAsync(Wish model)
    {
        var wish = await _context.WishList.SingleOrDefaultAsync(w => w.Perfume.Id == model.PerfumeId);
        if (wish != null)
        {
            return;
        }
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