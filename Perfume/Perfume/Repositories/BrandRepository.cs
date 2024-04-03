using DataBaseLayout;
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using Perfume.Models;

namespace Perfume.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly IContext _context;

    public BrandRepository(IContext context)
    {
        _context = context;
    }

    public async Task<List<Brand>> GetBrandsAsync()
    {
        var brands = await _context.Brands.ToListAsync();
        //var brandsDto = brands.Select(b => new BrandModel() { Name = b.Name }).ToList();
        return brands;
    }
}