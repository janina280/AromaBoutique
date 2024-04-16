using DataBaseLayout;
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using Perfume.Repositories.Interfaces;

namespace Perfume.Repositories;

public class FeatureRepository : IFeatureRepository
{
    private readonly IContext _context;

    public FeatureRepository(IContext context)
    {
        _context = context;
    }
    public async Task<List<Feature>> GetFeaturesAsync()
    {
        var feature = await _context.Features.Include(x=>x.Roles).ToListAsync();

        return feature;
    }

    public async Task<Feature> GetFeatureAsync(string name)
    {
        var feature = await _context.Features.Include(x => x.Roles).SingleAsync(f => f.Name == name);
        return feature;
    }

    public async Task CreateFeatureAsync(Feature model)
    {
        await _context.Features.AddAsync(model);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteFeatureAsync(string name)
    {
        var feature = await _context.Features.SingleAsync(scp => scp.Name == name);
        _context.Features.Remove(feature);

        await _context.SaveChangesAsync();
    }
}