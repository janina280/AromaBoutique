using Microsoft.AspNetCore.Mvc;

namespace Perfume.Controllers
{
    public class PerfumeController : Controller
    {
        public IActionResult Perfume()
        {
            return View();
        }
    }
}
