using Microsoft.AspNetCore.Mvc;

namespace Perfume.Controllers
{
    public class BrandsController : Controller
    {
        public IActionResult Brand()
        {
            return View();
        }
    }
}
