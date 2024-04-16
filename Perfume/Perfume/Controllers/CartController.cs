using Microsoft.AspNetCore.Mvc;
using Perfume.Models;
using Perfume.Repositories.Interfaces;

namespace Perfume.Controllers;

public class CartController : Controller
{
    private readonly IShoppingCartPerfumeRepository _perfumeRepository;

    public CartController(IShoppingCartPerfumeRepository perfumeRepository)
    {
        _perfumeRepository = perfumeRepository;
    }

    [HttpPost]
    public async Task<IActionResult> DeleteCartAsync(CartModel model)
    {
        await _perfumeRepository.DeleteShoppingCartPerfumeAsync(model.Id);

        return RedirectToAction("Cart", "Cart");
    }

    public async Task<IActionResult> CartAsync()
    {
        var shoppingCartPerfumes = await _perfumeRepository.GetShoppingCartPerfumesAsync();
        var shoppingCartPerfumesDto = shoppingCartPerfumes.Select(scp => new CartModel()
        {
            BrandTitle = scp.Perfume?.Brand.Name,
            Category = scp.Perfume?.PerfumeCategory.Name,
            Currency = scp.Perfume?.Currency,
            Price = scp.Perfume?.Price ?? 0,
            PerfumeTitle = scp.Perfume?.Name,
            ImageSource = scp.Perfume?.ProfileImage,
            Quantity = scp.Perfume?.Stock ?? 0,
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
        return View(shoppingCartPerfumesDto);
    }
}