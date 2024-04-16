using DataBaseLayout.Models;
using DataBaseLayout;
using Microsoft.EntityFrameworkCore;
using Perfume.Repositories.Interfaces;

namespace Perfume.Repositories;

public class PerfumeCategoryRepository: IPerfumeCategoryRepository
{
    private readonly IContext _context;

    public PerfumeCategoryRepository(IContext context)
    {
        _context = context;
    }
    public async Task<List<PerfumeCategory>> GetPerfumeCategoriesAsync()
    {
        var perfumeCategory = await _context.PerfumeCategories.Include(x=>x.Perfumes).ToListAsync();

        return perfumeCategory;
    }

    public async Task<PerfumeCategory> GetPerfumeCategoryAsync(string name)
    {
        var perfumeCategory = await _context.PerfumeCategories.Include(x => x.Perfumes).SingleAsync(pc => pc.Name == name);
        return perfumeCategory;
    }

    public async Task CreatePerfumeCategoryAsync(PerfumeCategory model)
    {
        await _context.PerfumeCategories.AddAsync(model);

        await _context.SaveChangesAsync();
    }

    public async Task DeletePerfumeCategoryAsync(string name)
    {
        var perfumeCategory = await _context.PerfumeCategories.SingleAsync(scp => scp.Name == name);
        _context.PerfumeCategories.Remove(perfumeCategory);

        await _context.SaveChangesAsync();
    }
}