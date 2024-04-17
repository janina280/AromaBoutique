using DataBaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Perfume.Models;
using Perfume.Repositories.Interfaces;
using Perfume.Services.Interfaces;

namespace Perfume.Controllers;

public class PerfumeController : Controller
{
    private readonly IShoppingCartPerfumeRepository _shoppingCartPerfumeRepository;
    private readonly IPerfumeRepository _perfumeRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly IPerfumeService _perfumeService;
    private readonly IBrandService _brandService;
    private readonly IPerfumeDetailsService _perfumeDetailsService;
    private readonly IPerfumeCategoryRepository _perfumeCategoryRepository;
    private readonly IWishRepository _wishRepository;

    public PerfumeController(
        IShoppingCartPerfumeRepository shoppingCartPerfumeRepository, 
        IBrandRepository brandRepository, 
        IPerfumeService perfumeService, 
        IPerfumeDetailsService perfumeDetailsService, 
        IPerfumeRepository perfumeRepository,
        IBrandService brandService,
        IPerfumeCategoryRepository perfumeCategoryRepository, 
        IWishRepository wishRepository)
    {
        _shoppingCartPerfumeRepository = shoppingCartPerfumeRepository;
        _brandRepository = brandRepository;
        _perfumeService = perfumeService;
        _perfumeDetailsService = perfumeDetailsService;
        _perfumeRepository = perfumeRepository;
        _brandService = brandService;
        _perfumeCategoryRepository = perfumeCategoryRepository;
        _wishRepository = wishRepository;
    }

    [HttpGet]
    public async Task<IActionResult> PerfumeAsync(string id)
    {
        var perfume = await _perfumeDetailsService.GetPerfumeDetailsAsync(Guid.Parse(id));
     
        return View(perfume);
    }
    [HttpGet]
    public async Task<IActionResult> AddPerfumeAsync()
    {
        await SetViewBagForBrandsAsync();
        await SetViewBagForCategoriesAsync();

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddPerfumeAsync(AddPerfumeModel model)
    {
        await SetViewBagForBrandsAsync();
        await SetViewBagForCategoriesAsync();


        await _perfumeService.AddPerfumeAsync(model);
        return RedirectToAction("Perfumes", "Perfume");
    }


    public IActionResult AddBrand()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddBrandAsync(AddBrandModel model)
    {
        await _brandService.AddBrandAsync(model);
        return RedirectToAction("Perfumes", "Perfume");
    }


    [HttpPost]
    public async Task<IActionResult> AddToWishListAsync(PerfumeModel model)
    {
        var perfume = await _perfumeRepository.GetPerfumeAsync(model.Id);
        //todo: getuser
        var entity = new Wish()
        {
            Id = Guid.NewGuid(),
            Perfume = perfume,
            User =
            new() {
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

        await _wishRepository.CreateWishAsync(entity);

        return RedirectToAction("Perfumes", "Perfume");
    }

    [HttpPost]
    public async Task<IActionResult> AddToShoppingCartAsync(PerfumeModel model)
    {
        var perfume = await _perfumeRepository.GetPerfumeAsync(model.Id);
        //todo: getuser
        var entity = new ShoppingCartPerfume()
        {
            Id = Guid.NewGuid(),
            Perfume = perfume,
            User =
            new (){
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

        await _shoppingCartPerfumeRepository.CreateShoppingCartPerfumeAsync(entity);

        return RedirectToAction("Perfumes", "Perfume");
    }
    public async Task<IActionResult> Perfumes()
    {
        var perfumes =await _perfumeService.GetPerfumesAsync();

        return View(perfumes);
    }

    [HttpPost]
    public async Task<IActionResult> DeletePerfumeAsync(PerfumeModel model)
    {
        await _perfumeRepository.DeletePerfumeAsync(model.Id);

        return RedirectToAction("Perfumes", "Perfume");
    }

    private async Task SetViewBagForBrandsAsync()
    {
        var brands = await _brandRepository.GetBrandsAsync();
        ViewBag.Brands = brands.Select(h => new SelectListItem()
        {
            Text = h.Name,
            Value = h.Name,
        });
    }
    private async Task SetViewBagForCategoriesAsync()
    {
        var categories = await _perfumeCategoryRepository.GetPerfumeCategoriesAsync();
        ViewBag.Categories = categories.Select(h => new SelectListItem()
        {
            Text = h.Name,
            Value = h.Name,
        });
    }
}