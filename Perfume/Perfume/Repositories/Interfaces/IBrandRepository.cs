using DataBaseLayout.Models;

namespace Perfume.Repositories.Interfaces;

public interface IBrandRepository
{
    Task<List<Brand>> GetBrandsAsync();
    Task CreateBrandAsync(Brand model);
    Task DeleteBrandAsync(string name);

}