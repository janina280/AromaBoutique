using Microsoft.AspNetCore.Mvc;

namespace Perfume.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
