using Microsoft.AspNetCore.Mvc;
using Perfume.Models;

namespace Perfume.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Cart()
        {
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
            };
            return View(mockCart);
        }
    }
}
