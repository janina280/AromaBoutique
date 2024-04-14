using DataBaseLayout.Models;
using DataBaseLayout;
using Microsoft.EntityFrameworkCore;
using Perfume.Repositories.Interfaces;

namespace Perfume.Repositories;

public class PerfumeRepository: IPerfumeRepository
{
    private readonly IContext _context;

    public PerfumeRepository(IContext context)
    {
        _context = context;
    }
    public async Task<List<DataBaseLayout.Models.Perfume>> GetPerfumesAsync()
    {
        var perfume = await _context.Perfumes.ToListAsync();

        return perfume;
    }

    public async Task CreatePerfumeAsync(DataBaseLayout.Models.Perfume model)
    {
        await _context.Perfumes.AddAsync(model);

        await _context.SaveChangesAsync();
    }

    public async Task DeletePerfumeAsync(Guid id)
    {
        var perfume = await _context.Perfumes.SingleAsync(scp => scp. Id == id);
        _context.Perfumes.Remove(perfume);

        await _context.SaveChangesAsync();
    }
}