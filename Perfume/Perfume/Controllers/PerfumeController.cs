using Microsoft.AspNetCore.Mvc;
using Perfume.Models;

namespace Perfume.Controllers;

public class PerfumeController : Controller
{
    public IActionResult Perfume()
    {
        return View();
    }
    public IActionResult Perfumes()
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
                BrandTitle = "Ralph Lauren",
                Currency = "RON",
                ImageSource = "~/images/Deals/D2-2.png",
                PerfumeTitle = "Polo Blue Parfum",
                Price = 402,
                Rating = 5
            },
            new PerfumeModel()
            {
                BrandTitle = "BULGARI",
                Currency = "RON",
                ImageSource = "~/images/Deals/D3-2.png",
                PerfumeTitle = "Bvlgari Man In Black",
                Price = 533,
                Rating = 5
            },
            new PerfumeModel()
            {
                BrandTitle = "Hugo Boss",
                Currency = "RON",
                ImageSource = "~/images/Deals/D1-2.png",
                PerfumeTitle = "BOSS Bottled Infinite",
                Price = 476,
                Rating = 4
            },
            new PerfumeModel()
            {
                BrandTitle = "Rabanne",
                Currency = "RON",
                ImageSource = "~/images/Deals/D4-2.png",
                PerfumeTitle = "Lady Million",
                Price = 524,
                Rating = 5
            },
            new PerfumeModel()
            {
                BrandTitle = "Narciso Rodriguez",
                Currency = "RON",
                ImageSource = "~/images/Deals/D6-1.png",
                PerfumeTitle = "for him Bleu Noir",
                Price = 385,
                Rating = 5
            },
            new PerfumeModel()
            {
                BrandTitle = "Nina Ricci",
                Currency = "RON",
                ImageSource = "~/images/Deals/D7-2.png",
                PerfumeTitle = "L'Extase",
                Price = 395,
                Rating = 5
            },
            new PerfumeModel()
            {
                BrandTitle = "Chopard",
                Currency = "RON",
                ImageSource = "~/images/Deals/D9-2.png",
                PerfumeTitle = "Wish",
                Price = 110,
                Rating = 5
            }
        };

        return View(mockPerfumes);
    }
}