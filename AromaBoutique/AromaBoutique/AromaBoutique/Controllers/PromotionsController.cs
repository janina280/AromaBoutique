using Microsoft.AspNetCore.Mvc;

namespace AromaBoutique.Controllers
{
    public class PromotionsController : Controller
    {
        public IActionResult Promotions()
        {
            return View();
        }
    }
}
