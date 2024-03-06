using Microsoft.AspNetCore.Mvc;

namespace AromaBoutique.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Account()
        {
            return View();
        }
    }
}
