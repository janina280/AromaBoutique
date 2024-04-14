using DataBaseLayout;
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using Perfume.Models;
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
        var shoppingCartPerfumes = await _context.ShoppingCartPerfumes.ToListAsync();
    
        return shoppingCartPerfumes;
    }

    public async Task CreateShoppingCartPerfumeAsync(ShoppingCartPerfume model)
    {
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