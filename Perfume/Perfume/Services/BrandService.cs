using DataBaseLayout.Models;
using Perfume.Models;
using Perfume.Repositories.Interfaces;
using Perfume.Services.Interfaces;

namespace Perfume.Services;

public class BrandService: IBrandService
{
    private readonly IBrandRepository _brandRepository;
    private readonly IImageConvertorService _imageConvertorService;

    public BrandService(IBrandRepository brandRepository, IImageConvertorService imageConvertorService)
    {
        _brandRepository = brandRepository;
        _imageConvertorService = imageConvertorService;
    }

    public async Task<List<BrandModel>> GetBrandsAsync()
    {
        var brands = await _brandRepository.GetBrandsAsync();
        var brandsDto = new List<BrandModel>();
        foreach (var brand in brands)
        {
            var img = await _imageConvertorService.ConvertByteArrayToFileFormAsync(new ImageDto()
            {
                FileName = brand.FileName,
                Image = brand.Image,
                ImageName = brand.ImageName
            });
            brandsDto.Add(new BrandModel()
            {
                Name = brand.Name,
                Description = brand.Description,
                Image = await _imageConvertorService.ConvertFormFileToImageAsync(img),
            });
        }

        return brandsDto;
    }

    public async Task AddBrandAsync(AddBrandModel model)
    {
        var brand = new Brand()
        {
            Name = model.Brand,
            Description = model.Description,
            Image = await _imageConvertorService.ConvertFileFormToByteArrayAsync(model.Image),
            FileName = model.Image.FileName,
            ImageName = model.Image.Name
        };
        await _brandRepository.CreateBrandAsync(brand);
    }

    public async Task<BrandModel> GetBrandAsync(string name)
    {
        var brand = await _brandRepository.GetBrandAsync(name);
        var img = await _imageConvertorService.ConvertByteArrayToFileFormAsync(new ImageDto()
        {
            FileName = brand.FileName,
            Image = brand.Image,
            ImageName = brand.ImageName
        });
        var brandDto = new BrandModel()
        {
            Description = brand.Description,
            Image = await _imageConvertorService.ConvertFormFileToImageAsync(img),
            Name = brand.FileName,
            ImageDisplay = await _imageConvertorService.ConvertFormFileToImageAsync(img)
        };
        return brandDto;
    }

    public async Task DeleteBrandAsync(string name)
    {
        await _brandRepository.DeleteBrandAsync(name);
    }
}