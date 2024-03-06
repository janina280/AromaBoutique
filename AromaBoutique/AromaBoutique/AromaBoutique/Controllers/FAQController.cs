using Microsoft.AspNetCore.Mvc;

namespace AromaBoutique.Controllers
{
    public class FAQController : Controller
    {
        public IActionResult Questions()
        {
            return View();
        }
    }
}
