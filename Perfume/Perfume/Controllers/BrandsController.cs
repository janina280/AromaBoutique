using Microsoft.AspNetCore.Mvc;
using Perfume.Models;
using Perfume.Repositories.Interfaces;
using Perfume.Services.Interfaces;

namespace Perfume.Controllers;

public class BrandsController : Controller
{
    private readonly IBrandRepository _brandRepository;
    private readonly IImageConvertorService _imageConvertorService;

    public BrandsController(IBrandRepository brandRepository, IImageConvertorService imageConvertorService)
    {
        _brandRepository = brandRepository;
        _imageConvertorService = imageConvertorService;
    }
    [HttpGet]
    public async Task<IActionResult> Brand(string name)
    {
       var brand = await _brandRepository.GetBrandAsync(name);
       var img= await _imageConvertorService.ConvertByteArrayToFileFormAsync(new ImageDto()
       {
           FileName = brand.FileName,
           Image = brand.Image,
           ImageName = brand.ImageName

       });
        var brandDto = new BrandModel()
       {
           Description = brand.Description,
           Name = brand.Name,
           Image = await _imageConvertorService.ConvertFormFileToImageAsync(img)
          
       };
        return View(brandDto);
    }


}