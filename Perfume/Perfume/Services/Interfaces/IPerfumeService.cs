using Perfume.Models;

namespace Perfume.Services.Interfaces
{
    public interface IPerfumeService
    {
        Task<List<PerfumeModel>> GetPerfumesAsync();

        Task<PerfumeModel> GetPerfumeAsync(Guid id);

        Task AddPerfumeAsync(AddPerfumeModel model);

        Task DeletePerfumeAsync(Guid id);
    }
}
