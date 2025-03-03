using DataBaseLayout.Models;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Perfume.Constants;
using Perfume.Models;
using Perfume.Repositories.Interfaces;
using Perfume.Services.Interfaces;
using System.IO;

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
    public async Task<IActionResult> PerfumesAsync(int pg = 1, string sortOrder = null, string category = null, string brand = null)
    {
        var perfumes = await _perfumeService.GetPerfumesAsync();
        Console.WriteLine($"{category}");

        // Filtrare după brand
        if (!string.IsNullOrEmpty(brand))
        {
            perfumes = perfumes.Where(p => p.BrandTitle == brand).ToList();
        }

        if (!string.IsNullOrEmpty(category))
        {
            perfumes = perfumes.Where(p => p.PerfumeCategory.Name == category).ToList();

        }

        // Sortare
        switch (sortOrder)
        {
            case "price_desc":
                perfumes = perfumes.OrderByDescending(p => p.Price).ToList();
                break;
            case "price_asc":
                perfumes = perfumes.OrderBy(p => p.Price).ToList();
                break;
            case "name_desc":
                perfumes = perfumes.OrderByDescending(p => p.PerfumeTitle).ToList();
                break;
            case "name_asc":
                perfumes = perfumes.OrderBy(p => p.PerfumeTitle).ToList();
                break;
        }

        const int pageSize = 8;
        if (pg < 1) pg = 1;
        int recsCount = perfumes.Count();
        var pager = new Pager(recsCount, pg, sortOrder, pageSize);
        int recSkip = (pg - 1) * pageSize;
        var data = perfumes.Skip(recSkip).Take(pager.PageSize).ToList();
        this.ViewBag.Pager = pager;

        return View(data);
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
        return RedirectToAction("Perfumes", "Perfume");
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
    public async Task<IActionResult> Perfumes(string searchString)
    {
        var perfumes = await _perfumeService.GetPerfumesAsync();
        //Search functionality
        if (!String.IsNullOrEmpty(searchString))
        {
            perfumes = perfumes.Where(p => p.PerfumeTitle.Contains(searchString) || p.BrandTitle.Contains(searchString))
                .ToList();
        }

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

    [HttpGet]
    public async Task<IActionResult> DownloadPdfAsync(Guid id)
    {
        var perfume = await _perfumeService.GetPerfumeAsync(id);

        // Creare PDF
        using MemoryStream ms = new MemoryStream();
        // Crearea unui obiect PdfWriter și asocierea cu MemoryStream
        var writer = new PdfWriter(ms);
        var pdf = new PdfDocument(writer);
        var document = new Document(pdf);

        // Adăugarea titlului și descrierii parfumului în PDF
        document.Add(new Paragraph($"Perfume: {perfume.PerfumeTitle}")
            .SetFontSize(20));
        document.Add(new Paragraph($"Brand: {perfume.BrandTitle}")
            .SetFontSize(18));
        document.Add(new Paragraph($"Category: {perfume.PerfumeCategory.Name}")
            .SetFontSize(18));
        document.Add(new Paragraph($"Price: {perfume.Price}")
            .SetFontSize(18));
        document.Add(new Paragraph($"Description: {perfume.Description}")
            .SetFontSize(12));

        // Închide documentul PDF
        document.Close();

        // Returnează fișierul PDF
        //ms.Seek(0, SeekOrigin.Begin);
        return File(ms.ToArray(), "application/pdf", $"{perfume.PerfumeTitle}_Description.pdf");
    }
}