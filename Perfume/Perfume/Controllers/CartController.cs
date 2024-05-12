using Microsoft.AspNetCore.Mvc;
using Perfume.Models;
using Perfume.Repositories.Interfaces;
using Perfume.Services.Interfaces;

namespace Perfume.Controllers;

public class CartController : Controller
{
    private readonly IShoppingCartPerfumeRepository _perfumeRepository;
    private readonly IImageConvertorService _imageConvertorService;
    private readonly IUserRepository _userRepository;
    public CartController(IShoppingCartPerfumeRepository perfumeRepository, IImageConvertorService imageConvertorService, IUserRepository userRepository)
    {
        _perfumeRepository = perfumeRepository;
        _imageConvertorService = imageConvertorService;
        _userRepository = userRepository;
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
        var user = await _userRepository.GetUserAsync(User.Identity.Name);
        var shoppingCartPerfumes = await _perfumeRepository.GetShoppingCartPerfumesByUserIdAsync(user.Id);

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
                Quantity = shoppingCartPerfume.Quantity,
                Id = shoppingCartPerfume.Id
            });
        }

        return View(shoppingCartPerfumesDto);
    }
}