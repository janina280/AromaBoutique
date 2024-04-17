using DataBaseLayout;
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using Perfume.Repositories.Interfaces;

namespace Perfume.Repositories;

public class ShoppingCartPerfumeRepository : IShoppingCartPerfumeRepository
{
    private readonly IContext _context;

    public ShoppingCartPerfumeRepository(IContext context)
    {
        _context = context;
    }

    public async Task<List<ShoppingCartPerfume>> GetShoppingCartPerfumesAsync()
    {
        var shoppingCartPerfumes = await _context.ShoppingCartPerfumes
            .Include(x=>x.User)
            .Include(x=>x.Perfume)
            .Include(x => x.Perfume.Brand)
            .Include(x => x.Perfume.PerfumeCategory)
            .Include(x => x.Perfume.Wishes)
            .Include(x => x.Perfume.Reviews)
            .Include(x => x.Perfume.ShoppingCartPerfumes)
            .Include(x => x.Perfume.PerfumeImages)
            .Include(x => x.Perfume.Deliveries)
            .ToListAsync();
    
        return shoppingCartPerfumes;
    }

    public async Task<ShoppingCartPerfume> GetShoppingCartPerfumeAsync(Guid id)
    {
        var shoppingCartPerfume = await _context.ShoppingCartPerfumes
            .Include(x => x.User)
            .Include(x => x.Perfume)
            .Include(x => x.Perfume.Brand)
            .Include(x => x.Perfume.PerfumeCategory)
            .Include(x => x.Perfume.Wishes)
            .Include(x => x.Perfume.Reviews)
            .Include(x => x.Perfume.ShoppingCartPerfumes)
            .Include(x => x.Perfume.PerfumeImages)
            .Include(x => x.Perfume.Deliveries)
            .SingleAsync(scp => scp.Id == id);
        return shoppingCartPerfume;
    }

    public async Task CreateShoppingCartPerfumeAsync(ShoppingCartPerfume model)
    {
        var cart = await _context.ShoppingCartPerfumes.SingleOrDefaultAsync(w => w.Perfume.Id == model.Perfume.Id);
        if (cart != null)
        {
            //todo: increase the quantity
            //cart.Perfume.
            return;
        }
        await _context.ShoppingCartPerfumes.AddAsync(model);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteShoppingCartPerfumeAsync(Guid id)
    {
        var shoppingCartPerfume = await _context.ShoppingCartPerfumes.SingleAsync(scp => scp.Id == id);
        _context.ShoppingCartPerfumes.Remove(shoppingCartPerfume);

        await _context.SaveChangesAsync();
    }
}