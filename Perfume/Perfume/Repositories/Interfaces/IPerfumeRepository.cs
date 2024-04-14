
namespace Perfume.Repositories.Interfaces;

public interface IPerfumeRepository
{
    Task<List<DataBaseLayout.Models.Perfume>> GetPerfumesAsync();
    Task CreatePerfumeAsync(DataBaseLayout.Models.Perfume model);
    Task DeletePerfumeAsync(Guid id);
}