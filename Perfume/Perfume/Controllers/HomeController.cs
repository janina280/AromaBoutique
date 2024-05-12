using Microsoft.AspNetCore.Mvc;
using Perfume.Models;
using System.Diagnostics;
using Perfume.Services.Interfaces;

namespace Perfume.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
  
    private readonly IImageConvertorService _imageConvertorService;
    private readonly IPromotionService _promotionService;

    public HomeController(ILogger<HomeController> logger,  IImageConvertorService imageConvertorService, IPromotionService promotionService)
    {
        _logger = logger;
        
        _imageConvertorService = imageConvertorService;
        _promotionService = promotionService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var promotions = await _promotionService.GetPromotionsAsync();

        return View(promotions);
    }
    [HttpGet]
    public async Task<IActionResult> AddPromotionAsync()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddPromotionAsync(AddPromotionModel model)
    {
         await _promotionService.AddPromotionAsync(model);
        return RedirectToAction("Index", "Home");
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}