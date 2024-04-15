using DataBaseLayout.Models;
using DataBaseLayout;
using Microsoft.EntityFrameworkCore;
using Perfume.Repositories.Interfaces;

namespace Perfume.Repositories;

public class PromotionRepository: IPromotionRepository
{
    private readonly IContext _context;

    public PromotionRepository(IContext context)
    {
        _context = context;
    }
    public async Task<List<Promotion>> GetPromotionsAsync()
    {
        var promotion = await _context.Promotions.ToListAsync();

        return promotion;
    }

    public async Task<Promotion> GetPromotionAsync(Guid id)
    {
        var promotion = await _context.Promotions.SingleAsync();
        return promotion;
    }

    public async Task CreatePromotionAsync(Promotion model)
    {
        await _context.Promotions.AddAsync(model);

        await _context.SaveChangesAsync();
    }

    public async Task DeletePromotionAsync(Guid id)
    {
        var promotion = await _context.Promotions.SingleAsync(scp => scp.Id == id);
        _context.Promotions.Remove(promotion);

        await _context.SaveChangesAsync();
    }
}