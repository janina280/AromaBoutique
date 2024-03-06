using Microsoft.AspNetCore.Mvc;

namespace AromaBoutique.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }
    }
}
