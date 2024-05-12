using DataBaseLayout.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Perfume.Constants;
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
    private readonly IPerfumeCategoryRepository _perfumeCategoryRepository;
    private readonly IWishRepository _wishRepository;
  private readonly IUserRepository _userRepository;

    public PerfumeController(
        IShoppingCartPerfumeRepository shoppingCartPerfumeRepository, 
        IBrandRepository brandRepository, 
        IPerfumeService perfumeService, 
        IPerfumeRepository perfumeRepository,
        IPerfumeCategoryRepository perfumeCategoryRepository, 
        IWishRepository wishRepository, IUserRepository userRepository)
    {
        _shoppingCartPerfumeRepository = shoppingCartPerfumeRepository;
        _brandRepository = brandRepository;
        _perfumeService = perfumeService;
        _perfumeRepository = perfumeRepository;
        _perfumeCategoryRepository = perfumeCategoryRepository;
        _wishRepository = wishRepository;
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> PerfumeAsync(string id)
    {
        var perfume = await _perfumeService.GetPerfumeAsync(Guid.Parse(id));
     
        return View(perfume);
    }

    [HttpGet]
    public async Task<IActionResult> PerfumesAsync()
    {
        var perfumes = await _perfumeService.GetPerfumesAsync();

        return View(perfumes);
    }

    [HttpGet]
    public async Task<IActionResult> AddPerfumeAsync()
    {
        await SetViewBagForBrandsAsync();
        await SetViewBagForCategoriesAsync();

        return View();
    }

    
    [HttpPost]
    [Authorize(Roles = Roles.Administrator)]
    public async Task<IActionResult> AddPerfumeAsync(AddPerfumeModel model)
    {
        await SetViewBagForBrandsAsync();
        await SetViewBagForCategoriesAsync();


        await _perfumeService.AddPerfumeAsync(model);
        return RedirectToAction("Perfumes", "Perfume");
    }
    


    [HttpPost]
    public async Task<IActionResult> AddToWishListAsync(PerfumeModel model)
    {
        var user = await _userRepository.GetUserAsync(User.Identity.Name);
        await _wishRepository.CreateWishAsync(new Wish()
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            PerfumeId = model.Id,
        });
        return RedirectToAction("Wish", "Wish");
    }

    [HttpPost]
    public async Task<IActionResult> AddToShoppingCartAsync(PerfumeModel model)
    {
        var user = await _userRepository.GetUserAsync(User.Identity.Name);
        await _shoppingCartPerfumeRepository.CreateShoppingCartPerfumeAsync(new ShoppingCartPerfume()
            {
                PerfumeId = model.Id,
                UserId = user.Id,
                Id = Guid.NewGuid()
            }
        );
        
        return RedirectToAction("Perfumes", "Perfume");
    }
    public async Task<IActionResult> Perfumes()
    {
        var perfumes =await _perfumeService.GetPerfumesAsync();

        return View(perfumes);
    }

    [HttpPost]
    [Authorize(Roles = Roles.Administrator)]
    public async Task<IActionResult> DeletePerfumeAsync(PerfumeModel model)
    {
        await _perfumeRepository.DeletePerfumeAsync(model.Id);

        return RedirectToAction("Perfumes", "Perfume");
    }

    private async Task SetViewBagForBrandsAsync()
    {
        var brands = await _brandRepository.GetBrandsAsync();
        ViewBag.Brands = brands.Select(b => new SelectListItem()
        {
            Text = b.Name,
            Value = b.Name,
        });
    }
    private async Task SetViewBagForCategoriesAsync()
    {
        var categories = await _perfumeCategoryRepository.GetPerfumeCategoriesAsync();
        ViewBag.Categories = categories.Select(c => new SelectListItem()
        {
            Text = c.Name,
            Value = c.Name,
        });
    }
}