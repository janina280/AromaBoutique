
namespace Perfume.Repositories.Interfaces;

public interface IPerfumeRepository
{
    Task<List<DataBaseLayout.Models.Perfume>> GetPerfumesAsync();
    Task<DataBaseLayout.Models.Perfume> GetPerfumeAsync(Guid id);
    Task CreatePerfumeAsync(DataBaseLayout.Models.Perfume model);
    Task DeletePerfumeAsync(Guid id);
}