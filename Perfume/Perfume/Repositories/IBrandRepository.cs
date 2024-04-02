using Perfume.Models;

namespace Perfume.Repositories;

public interface IBrandRepository
{
    Task<List<BrandModel>> GetBrandsAsync();
}