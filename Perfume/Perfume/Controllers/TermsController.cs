using Microsoft.AspNetCore.Mvc;

namespace Perfume.Controllers;

public class TermsController : Controller
{
    public IActionResult Terms()
    {
        return View();
    }
}