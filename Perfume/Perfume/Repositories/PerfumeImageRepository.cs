using DataBaseLayout.Models;
using DataBaseLayout;
using Microsoft.EntityFrameworkCore;
using Perfume.Repositories.Interfaces;

namespace Perfume.Repositories;

public class PerfumeImageRepository: IPerfumeImageRepository
{
    private readonly IContext _context;

    public PerfumeImageRepository(IContext context)
    {
        _context = context;
    }
    public async Task<List<PerfumeImage>> GetPerfumeImagesAsync()
    {
        var perfumeImage = await _context.PerfumeImages.Include(x=>x.Perfume).ToListAsync();

        return perfumeImage;
    }

    public async Task<PerfumeImage> GetPerfumeImageAsync(Guid id)
    {
        var perfumeImage = await _context.PerfumeImages.Include(x => x.Perfume).SingleAsync(pi => pi.Id == id);
        return perfumeImage;
    }

    public async Task CreatePerfumeImageAsync(PerfumeImage model)
    {
        await _context.PerfumeImages.AddAsync(model);

        await _context.SaveChangesAsync();
    }

    public async Task DeletePerfumeImageAsync(Guid id)
    {
        var perfumeImage = await _context.PerfumeImages.SingleAsync(scp => scp.Id == id);
        _context.PerfumeImages.Remove(perfumeImage);

        await _context.SaveChangesAsync();
    }
}