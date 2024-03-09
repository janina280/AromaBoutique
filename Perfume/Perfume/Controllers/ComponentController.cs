using Microsoft.AspNetCore.Mvc;

namespace Perfume.Controllers
{
    public class ComponentController : Controller
    {
        public IActionResult Component()
        {
            return View();
        }
    }
}
