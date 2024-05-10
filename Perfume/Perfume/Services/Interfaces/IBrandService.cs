using Perfume.Models;

namespace Perfume.Services.Interfaces;

public interface IBrandService
{
    Task<List<BrandModel>> GetBrandsAsync();
    Task AddBrandAsync(AddBrandModel model);
    Task<BrandModel> GetBrandAsync(string name);
    Task DeleteBrandAsync(string name);
}