using Perfume.Models;
using Perfume.Repositories.Interfaces;
using Perfume.Services.Interfaces;

namespace Perfume.Services;

public class PerfumeService : IPerfumeService
{
    private readonly IPerfumeRepository _perfumeRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly IPerfumeCategoryRepository _perfumeCategoryRepository;
    private readonly IImageConvertorService _imageConvertorService;

    public PerfumeService(IPerfumeRepository perfumeRepository, IPerfumeCategoryRepository perfumeCategoryRepository, IBrandRepository brandRepository, IImageConvertorService imageConvertorService)
    {
        _perfumeRepository = perfumeRepository;
        _perfumeCategoryRepository = perfumeCategoryRepository;
        _brandRepository = brandRepository;
        _imageConvertorService = imageConvertorService;
    }

    public async Task<List<PerfumeModel>> GetPerfumesAsync()
    {
        var perfumes = await _perfumeRepository.GetPerfumesAsync();
        var perfumesDto = new List<PerfumeModel>();
        foreach (var perfume in perfumes)
        {
            var img = await _imageConvertorService.ConvertByteArrayToFileFormAsync(new ImageDto()
            {
                FileName = perfume.FileName,
                Image = perfume.ProfileImage,
                ImageName = perfume.ImageName,
            });
            perfumesDto.Add(new PerfumeModel()
            {
                BrandTitle = perfume.Brand.Name,
                Currency = perfume.Currency,
                Id = perfume.Id,
                PerfumeTitle = perfume.Name,
                Price = perfume.Price,
                Rating = perfume.Rating,
                DisplayImage = await _imageConvertorService.ConvertFormFileToImageAsync(img),
                PerfumeCategory = perfume.PerfumeCategory,
                Description = perfume.Description
            });
        }
        return perfumesDto;

    }

    public async Task<PerfumeModel> GetPerfumeAsync(Guid id)
    {
        var perfume = await _perfumeRepository.GetPerfumeAsync(id);
        var img = await _imageConvertorService.ConvertByteArrayToFileFormAsync(new ImageDto()
        {
            FileName = perfume.FileName,
            Image = perfume.ProfileImage,
            ImageName = perfume.ImageName
        });
        var perfumeDto = new PerfumeModel()
        {
            Description = perfume.Description,
            Currency = perfume.Currency,
            Price = perfume.Price,
            BrandTitle = perfume.Brand.Name,
            PerfumeTitle = perfume.Name,
            Rating = perfume.Rating,
            Id = perfume.Id,
            DisplayImage = await _imageConvertorService.ConvertFormFileToImageAsync(img), 
            PerfumeCategory = perfume.PerfumeCategory
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
            ProfileImage = await _imageConvertorService.ConvertFileFormToByteArrayAsync(model.Image),
            Brand = brand,
            PerfumeCategory = category,
            Rating = 0,
            RatingAppearance = 0,
            RatingIntension = 0,
            RatingPersistence = 0,
            Stock = model.Stock,
            FileName = model.Image.FileName,
            ImageName = model.Image.Name
        };
        await _perfumeRepository.CreatePerfumeAsync(perfume);
    }

    public async Task DeletePerfumeAsync(Guid id)
    {
        await _perfumeRepository.DeletePerfumeAsync(id);
    }
}