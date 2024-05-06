using Microsoft.AspNetCore.Mvc;
using Perfume.Models;
using Perfume.Repositories.Interfaces;

namespace Perfume.Controllers;

public class WishController: Controller
{
    private readonly IWishRepository _wishRepository;
    public WishController(IWishRepository wishRepository)
    {
        _wishRepository = wishRepository;
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
        var wishesDto = wishes.Select(scp => new WishModel()
        {
            BrandTitle = scp.Perfume?.Brand.Name,
            Category = scp.Perfume?.PerfumeCategory.Name,
            Currency = scp.Perfume?.Currency,
            Price = scp.Perfume?.Price ?? 0,
            PerfumeTitle = scp.Perfume?.Name,
            ImageSource = scp.Perfume?.ProfileImage,
            Id = scp.Id
        }).ToList();

        /*
        var mockCart = new List<CartModel>()
        {
            new CartModel()
            {
                BrandTitle = "Versace",
                Category = "Femei",
                Currency = "RON",
                ImageSource = "~/images/new-product/N3.png",
                PerfumeTitle = "Eros Pour Femme",
                Price = 410
            },
            new CartModel()
            {
                BrandTitle = "BULGARI",
                Category = "Femei",
                Currency = "RON",
                ImageSource = "~/images/small-product/mini2.png",
                PerfumeTitle = "Rose Goldea Eau de Parfum",
                Price = 749
            }
        };*/
        return View(wishesDto);
    }
}