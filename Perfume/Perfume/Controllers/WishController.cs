using System.Net.Security;
using DataBaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Perfume.Models;
using Perfume.Repositories.Interfaces;
using Perfume.Services.Interfaces;

namespace Perfume.Controllers;

public class WishController: Controller
{
    private readonly IWishRepository _wishRepository;
    private readonly IImageConvertorService _imageConvertorService;
    public WishController(IWishRepository wishRepository, IImageConvertorService imageConvertorService)
    {
        _wishRepository = wishRepository;
        _imageConvertorService = imageConvertorService;
    }
    [HttpPost]
    public async Task<IActionResult> DeleteWishAsync(CartModel model)
    {
        await _wishRepository.DeleteWishAsync(model.Id);

        return RedirectToAction("Wish", "Wish");
    }

    public async Task<IActionResult> WishAsync()
    {
        var wishes = await _wishRepository.GetWishListAsync();
        var wishesDto = new List<WishModel>();
        foreach (var wish in wishes)
        {
            var img = await _imageConvertorService.ConvertByteArrayToFileFormAsync(new ImageDto()
            {
                FileName = wish.Perfume.FileName,
                Image = wish.Perfume.ProfileImage,
                ImageName = wish.Perfume.ImageName
            });
            wishesDto.Add(new WishModel()
            {
                BrandTitle = wish.Perfume?.Brand.Name,
                Category = wish.Perfume?.PerfumeCategory.Name,
                Currency = wish.Perfume?.Currency,
                Price = wish.Perfume?.Price ?? 0,
                PerfumeTitle = wish.Perfume?.Name,
                Id = wish.Perfume.Id,
                ImageSource = await _imageConvertorService.ConvertFormFileToImageAsync(img)
            });
        }
        return View(wishesDto);
    }
}