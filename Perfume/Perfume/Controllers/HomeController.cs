using Microsoft.AspNetCore.Mvc;
using Perfume.Models;
using System.Diagnostics;
using DataBaseLayout.Models;
using Perfume.Repositories.Interfaces;
using Perfume.Services.Interfaces;

namespace Perfume.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPromotionRepository _promotionRepository;
    private readonly IImageConvertorService _imageConvertorService;

    public HomeController(ILogger<HomeController> logger, IPromotionRepository promotionRepository, IImageConvertorService imageConvertorService)
    {
        _logger = logger;
        _promotionRepository = promotionRepository;
        _imageConvertorService = imageConvertorService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var promotions = await _promotionRepository.GetPromotionsAsync();
        var promotionDto = new List<PromotionModel>();
        foreach (var promotion in promotions)
        {
            var img = await _imageConvertorService.ConvertByteArrayToFileFormAsync(new ImageDto()
            {
                FileName = promotion.FileName,
                Image = promotion.Image,
                ImageName = promotion.ImageName

            });
            promotionDto.Add(new PromotionModel()
            {
                Description = promotion.Description,
                Image = await _imageConvertorService.ConvertFormFileToImageAsync(img)
                
            });
        }

        return View(promotionDto);
    }

    public async Task<IActionResult> AddPromotion()
    {

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