using DataBaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Perfume.Models;
using Perfume.Repositories.Interfaces;

namespace Perfume.Controllers;

public class PerfumeController : Controller
{
    private readonly IShoppingCartPerfumeRepository _perfumeRepository;

    public PerfumeController(IShoppingCartPerfumeRepository perfumeRepository)
    {
        _perfumeRepository = perfumeRepository;
    }

    public IActionResult Perfume()
    {
        return View();
    }
    public IActionResult AddPerfume()
    {
        return View();
    }
    public IActionResult AddBrand()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddToShoppingCartAsync(PerfumeModel model)
    {
        var entity = new ShoppingCartPerfume()
        {
            Id = Guid.NewGuid(),
            Perfume = new DataBaseLayout.Models.Perfume()
            {
                Brand = new Brand()
                {
                    Name = Guid.NewGuid().ToString()
                },
                Name = "test",
                Currency = "test",
                PerfumeCategory = new PerfumeCategory()
                {
                    Name = Guid.NewGuid().ToString()
                },
                Deliveries = new List<Delivery>(){},
                Id = Guid.NewGuid(),
                Price = 4.0,
                ProfileImage = "test",
                Rating = 2.0,
                Stock = 2,
                RatingAppearance = 2.0,
                RatingIntension = 2.0,
                PerfumeImages = new List<PerfumeImage>(),
                RatingPersistence = 2.0,
            },
            User = new User()
            {
                Email = "test",
                FirstName = "test",
                LastName = "test",
                Id = Guid.NewGuid(),
                Password = "test",
                Role = new Role()
                {
                    Name = Guid.NewGuid().ToString(),Features = new List<Feature>(){ new Feature(){Name = Guid.NewGuid().ToString(), HTMLFlag = "test"}}
                },
                Reviews = new List<Review>(),
                ReviewConversations = new List<ReviewConversation>(),
                Wishes = new List<Wish>()
            }
        };

        await _perfumeRepository.CreateShoppingCartPerfumeAsync(entity);

        return RedirectToAction("Perfumes", "Perfume");
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