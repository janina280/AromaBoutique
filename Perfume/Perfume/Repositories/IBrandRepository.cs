using DataBaseLayout.Models;
using Perfume.Models;

namespace Perfume.Repositories;

public interface IBrandRepository
{
    Task<List<Brand>> GetBrandsAsync();
}