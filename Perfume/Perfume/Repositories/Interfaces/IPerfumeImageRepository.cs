using DataBaseLayout.Models;

namespace Perfume.Repositories.Interfaces;

public interface IPerfumeImageRepository
{
    Task<List<PerfumeImage>> GetPerfumeImagesAsync();
    Task CreatePerfumeImageAsync(PerfumeImage model);
    Task DeletePerfumeImageAsync(Guid id);
}