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
                    Category = "Barbati",
                    Currency = "RON",
                    ImageSource = "~/images/onsale/D10-1.png",
                    PerfumeTitle = "Test",
                    Price = 470
                }
            };
            return View(mockCart);
        }
    }
}
