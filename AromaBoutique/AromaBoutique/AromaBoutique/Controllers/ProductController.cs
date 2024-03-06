using Microsoft.AspNetCore.Mvc;

namespace AromaBoutique.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Product()
        {
            return View();
        }

        public IActionResult ProductDetail()
        {
            return View();
        }

        public IActionResult Brands()
        {
            return View();
        }

    }
}
