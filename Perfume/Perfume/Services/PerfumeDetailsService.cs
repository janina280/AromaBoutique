using Perfume.Models;
using Perfume.Repositories.Interfaces;
using Perfume.Services.Interfaces;

namespace Perfume.Services
{
    public class PerfumeDetailsService: IPerfumeDetailsService
    {
        private readonly IPerfumeRepository _perfumeRepository;

        public PerfumeDetailsService(IPerfumeRepository perfumeRepository)
        {
            _perfumeRepository = perfumeRepository;
        }
        public async Task<PerfumeDetailsModel> GetPerfumeDetailsAsync(Guid id)
        {
            var details = await _perfumeRepository.GetPerfumeAsync(id);
            var detailsDto = new PerfumeDetailsModel()
            {
                Description = details.Description,

            };
            return detailsDto;
        }
    }
}
