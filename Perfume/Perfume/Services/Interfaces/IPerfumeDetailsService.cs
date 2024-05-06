using Perfume.Models;

namespace Perfume.Services.Interfaces;

public interface IPerfumeDetailsService
{
    Task<PerfumeDetailsModel> GetPerfumeDetailsAsync(Guid id);
}