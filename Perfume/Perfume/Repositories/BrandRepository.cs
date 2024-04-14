using DataBaseLayout;
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using Perfume.Models;
using Perfume.Repositories.Interfaces;

namespace Perfume.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly IContext _context;

    public BrandRepository(IContext context)
    {
        _context = context;
    }

    public async Task CreateBrandAsync(Brand model)
    {
        await _context.Brands.AddAsync(model);

        await _context.SaveChangesAsync();

    }

    public async Task DeleteBrandAsync(string name)
    {
        var brand = await _context.Brands.SingleAsync(scp => scp.Name == name);
        _context.Brands.Remove(brand);

        await _context.SaveChangesAsync();
    }

    public async Task<List<Brand>> GetBrandsAsync()
    {
        var brands = await _context.Brands.ToListAsync();
        //var brandsDto = brands.Select(b => new BrandModel() { Name = b.Name }).ToList();
        return brands;
    }
}