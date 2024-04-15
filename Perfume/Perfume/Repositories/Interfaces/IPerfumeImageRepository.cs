using DataBaseLayout.Models;

namespace Perfume.Repositories.Interfaces;

public interface IPerfumeImageRepository
{
    Task<List<PerfumeImage>> GetPerfumeImagesAsync();
    Task<PerfumeImage> GetPerfumeImageAsync(Guid  id);
    Task CreatePerfumeImageAsync(PerfumeImage model);
    Task DeletePerfumeImageAsync(Guid id);
}