using Perfume.Models;
using Perfume.Repositories.Interfaces;
using Perfume.Services.Interfaces;

namespace Perfume.Services
{
    public class PerfumeService : IPerfumeService
    {
        private readonly IPerfumeRepository _perfumeRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IPerfumeCategoryRepository _perfumeCategoryRepository;

        public PerfumeService(IPerfumeRepository perfumeRepository, IPerfumeCategoryRepository perfumeCategoryRepository, IBrandRepository brandRepository)
        {
            _perfumeRepository = perfumeRepository;
            _perfumeCategoryRepository = perfumeCategoryRepository;
            _brandRepository = brandRepository;
        }

        public async Task<List<PerfumeModel>> GetPerfumesAsync()
        {
            var perfumes = await _perfumeRepository.GetPerfumesAsync();
            var perfumesDto = perfumes.Select(p => new PerfumeModel()
            {
                Currency = p.Currency,
                Price = p.Price,
                BrandTitle = p.Brand.Name,
                PerfumeTitle = p.Name,
                Rating = p.Rating,
                ImageSource = p.ProfileImage,
                Id = p.Id

            }).ToList();
            return perfumesDto;
        }

        public async Task<PerfumeModel> GetPerfumeAsync(Guid id)
        {
            var perfume = await _perfumeRepository.GetPerfumeAsync(id);
            var perfumeDto = new PerfumeDetailsModel()
            {
                Description = perfume.Description,
                Currency = perfume.Currency,
                Price = perfume.Price,
                BrandTitle = perfume.Brand.Name,
                PerfumeTitle = perfume.Name,
                Rating = perfume.Rating,
                ImageSource = perfume.ProfileImage
            };
            return perfumeDto;
        }

        public async Task AddPerfumeAsync(AddPerfumeModel model)
        {
            var brand = await _brandRepository.GetBrandAsync(model.Brand);
            var category = await _perfumeCategoryRepository.GetPerfumeCategoryAsync(model.Category);

            var perfume = new DataBaseLayout.Models.Perfume()
            {
                Id = Guid.NewGuid(),
                Currency = model.Currency,
                Description = model.Description,
                Price = model.Price,
                Name = model.PerfumeName,
                ProfileImage = model.Image,
                Brand = brand,
                PerfumeCategory = category,
                Rating = 0,
                RatingAppearance = 0,
                RatingIntension = 0,
                RatingPersistence = 0,
                Stock = model.Stock,
                
            };
            await _perfumeRepository.CreatePerfumeAsync(perfume);
        }

        public async Task DeletePerfumeAsync(Guid id)
        {
            await _perfumeRepository.DeletePerfumeAsync(id);
        }
    }
}
