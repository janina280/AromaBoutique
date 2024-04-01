using Microsoft.AspNetCore.Mvc;

namespace Perfume.Controllers;

public class ContactController : Controller
{
    public IActionResult Contact()
    {
        return View();
    }
}