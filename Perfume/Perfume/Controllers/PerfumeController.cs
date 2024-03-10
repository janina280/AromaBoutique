using Microsoft.AspNetCore.Mvc;
using Perfume.Models;

namespace Perfume.Controllers;

public class PerfumeController : Controller
{
    public IActionResult Perfume()
    {
        var mockPerfumes = new List<PerfumeModel>()
        {
            new PerfumeModel()
            {
                BrandTitle = "Versace",
                Currency = "RON",
                ImageSource = "~/images/new-product/N3.png",
                PerfumeTitle = "Eros Pour Femme",
                Price = 410,
                Rating = 5
            },
            new PerfumeModel()
            {
                BrandTitle = "Versace",
                Currency = "RON",
                ImageSource = "~/images/brands/DIOR.JPG",
                PerfumeTitle = "Eros Pour Femme",
                Price = 410,
                Rating = 5
            },
            new PerfumeModel()
            {
                BrandTitle = "Versace",
                Currency = "RON",
                ImageSource = "~/images/new-product/N3.png",
                PerfumeTitle = "Eros Pour Femme",
                Price = 410,
                Rating = 5
            },
            new PerfumeModel()
            {
                BrandTitle = "Versace",
                Currency = "RON",
                ImageSource = "~/images/new-product/N3.png",
                PerfumeTitle = "Eros Pour Femme",
                Price = 410,
                Rating = 5
            },
            new PerfumeModel()
            {
                BrandTitle = "Versace",
                Currency = "RON",
                ImageSource = "~/images/new-product/N3.png",
                PerfumeTitle = "Eros Pour Femme",
                Price = 410,
                Rating = 5
            },
            new PerfumeModel()
            {
                BrandTitle = "Versace",
                Currency = "RON",
                ImageSource = @"~/images/new-product/N3.png",
                PerfumeTitle = "Eros Pour Femme",
                Price = 410,
                Rating = 5
            }
        };

        return View(mockPerfumes);
    }
}