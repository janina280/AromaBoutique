using Perfume.Models;

namespace Perfume.Services.Interfaces;

public interface IBrandService
{
    Task<List<AddBrandModel>> GetBrandsAsync();

    Task AddBrandAsync(AddBrandModel model);
}