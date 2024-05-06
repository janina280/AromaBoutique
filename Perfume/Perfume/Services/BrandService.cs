using DataBaseLayout.Models;
using Perfume.Models;
using Perfume.Repositories.Interfaces;
using Perfume.Services.Interfaces;

namespace Perfume.Services;

public class BrandService: IBrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<List<AddBrandModel>> GetBrandsAsync()
    {
        var brands = await _brandRepository.GetBrandsAsync();
        var brandsDto=brands.Select(b=>new AddBrandModel()
        {
            Brand = b.Name,
            Description = b.Description,
            Image = b.Image
        }).ToList();

        return brandsDto;
    }

    public async Task AddBrandAsync(AddBrandModel model)
    {
        var brand = new Brand()
        {
            Name = model.Brand,
            Description = model.Description,
            Image = model.Image,
        };
        await _brandRepository.CreateBrandAsync(brand);
    }
}