using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Perfume.Constants;
using Perfume.Models;
using Perfume.Repositories.Interfaces;
using Perfume.Services.Interfaces;

namespace Perfume.Controllers;

public class CartController : Controller
{
    private readonly IShoppingCartPerfumeRepository _perfumeRepository;
    private readonly IImageConvertorService _imageConvertorService;

    public CartController(IShoppingCartPerfumeRepository perfumeRepository, IImageConvertorService imageConvertorService)
    {
        _perfumeRepository = perfumeRepository;
        _imageConvertorService = imageConvertorService;
    }

    [HttpPost]
    public async Task<IActionResult> DeleteCartAsync(CartModel model)
    {
        await _perfumeRepository.DeleteShoppingCartPerfumeAsync(model.Id);

        return RedirectToAction("Cart", "Cart");
    }

    [HttpGet]
    public async Task<IActionResult> CartAsync()
    {
        var shoppingCartPerfumes = await _perfumeRepository.GetShoppingCartPerfumesAsync();

        var shoppingCartPerfumesDto = new List<CartModel>();
        foreach (var shoppingCartPerfume in shoppingCartPerfumes)
        {
            var img = await _imageConvertorService.ConvertByteArrayToFileFormAsync(new ImageDto()
            {
                FileName = shoppingCartPerfume.Perfume.FileName,
                Image = shoppingCartPerfume.Perfume.ProfileImage,
                ImageName = shoppingCartPerfume.Perfume.ImageName
            });
            shoppingCartPerfumesDto.Add(new CartModel()
            {
                BrandTitle = shoppingCartPerfume.Perfume?.Brand.Name,
                Category = shoppingCartPerfume.Perfume?.PerfumeCategory.Name,
                Currency = shoppingCartPerfume.Perfume?.Currency,
                Price = shoppingCartPerfume.Perfume?.Price ?? 0,
                PerfumeTitle = shoppingCartPerfume.Perfume?.Name,
                ImageSource = await _imageConvertorService.ConvertFormFileToImageAsync(img),
                Quantity = shoppingCartPerfume.Perfume?.Stock ?? 0,
                Id = shoppingCartPerfume.Id
            });
        }

        return View(shoppingCartPerfumesDto);
    }
}