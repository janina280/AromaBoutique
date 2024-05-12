using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Perfume.Constants;
using Perfume.Models;
using Perfume.Services.Interfaces;

namespace Perfume.Controllers;

public class BrandsController : Controller
{
    private readonly IBrandService _brandService;
    private readonly IImageConvertorService _imageConvertorService;

    public BrandsController(IImageConvertorService imageConvertorService, IBrandService brandService)
    {
        _imageConvertorService = imageConvertorService;
        _brandService = brandService;
    }

    [HttpGet]
    public async Task<IActionResult> Brand(string name)
    {
        var brand = await _brandService.GetBrandAsync(name);

        return View(brand);
    }
    [HttpGet]
    public IActionResult AddBrand()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = Roles.Administrator)]
    public async Task<IActionResult> AddBrandAsync(AddBrandModel model)
    {
        await _brandService.AddBrandAsync(model);
        return RedirectToAction("Perfumes", "Perfume");
    }

    public async Task<IActionResult> DeleteBrandAsync(BrandModel model)
    {
        await _brandService.DeleteBrandAsync(model.Name);
        return RedirectToAction("Perfumes", "Perfume");
    }


}