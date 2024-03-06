using Microsoft.AspNetCore.Mvc;

namespace AromaBoutique.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult ShoppingCart()
        {
            return View();
        }
    }
}
