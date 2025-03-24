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
using Perfume.Services;
using Perfume.Services.Interfaces;
using System.IO;
using System.Text;

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

    private readonly ISearchEngine _searchEngine;

    public PerfumeController(
        IShoppingCartPerfumeRepository shoppingCartPerfumeRepository,
        IBrandRepository brandRepository,
        IPerfumeService perfumeService,
        IPerfumeRepository perfumeRepository,
        IPerfumeCategoryRepository perfumeCategoryRepository,
        IWishRepository wishRepository, IUserRepository userRepository, ISearchEngine searchEngine)
    {
        _shoppingCartPerfumeRepository = shoppingCartPerfumeRepository;
        _brandRepository = brandRepository;
        _perfumeService = perfumeService;
        _perfumeRepository = perfumeRepository;
        _perfumeCategoryRepository = perfumeCategoryRepository;
        _wishRepository = wishRepository;
        _userRepository = userRepository;
        _searchEngine = searchEngine;
    }

    [HttpGet]
    public async Task<IActionResult> PerfumeAsync(string id)
    {
        var perfume = await _perfumeService.GetPerfumeAsync(Guid.Parse(id));

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
    [Authorize(Roles = Roles.Administrator)]
    public async Task<IActionResult> AddPerfumeAsync(AddPerfumeModel model)
    {
        await SetViewBagForBrandsAsync();
        await SetViewBagForCategoriesAsync();


        var id = await _perfumeService.AddPerfumeAsync(model);

        _searchEngine.AddToIndex(id, model.Description);
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

    public async Task<IActionResult> Perfumes(string searchString, int pg = 1, string sortOrder = null,
        string category = null,
        string brand = null)
    {
        if (!string.IsNullOrEmpty(searchString))
        {
            //HttpContext.Session.Set("SearchString", Encoding.UTF8.GetBytes(searchString));
        }
        else
        {
            //searchString = HttpContext.Session.GetString("SearchString")!;
        }

        var perfumes = new List<PerfumeModel>();

        if (!string.IsNullOrEmpty(searchString))
        {
            await _searchEngine.GetDataAsync();
            _searchEngine.Index();
            var perfumeIds = _searchEngine.Search(searchString);

            foreach (var perfumeId in perfumeIds)
            {
                perfumes.Add(await _perfumeService.GetPerfumeAsync(Guid.Parse(perfumeId)));
            }
        }
        else
        {
            perfumes = await _perfumeService.GetPerfumesAsync();
        }

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

        return View(perfumes);
    }

    [HttpPost]
    [Authorize(Roles = Roles.Administrator)]
    public async Task<IActionResult> DeletePerfumeAsync(PerfumeModel model)
    {
        await _perfumeRepository.DeletePerfumeAsync(model.Id);

        _searchEngine.DeleteFromIndex(model.Id.ToString());

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

        using MemoryStream ms = new MemoryStream();

        var writer = new PdfWriter(ms);
        var pdf = new PdfDocument(writer);
        var document = new Document(pdf);

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

        document.Close();
        return File(ms.ToArray(), "application/pdf", $"{perfume.PerfumeTitle}_Description.pdf");
    }

    [HttpGet]
    public async Task<IActionResult> SearchPerfumes(string searchTerm)
    {
        if (string.IsNullOrEmpty(searchTerm))
        {
            return Json(new List<object>());
        }

        var perfumes = await _perfumeRepository.GetPerfumesAsync();

        var trie = new Trie();
        foreach (var perfume in perfumes)
        {
            trie.Insert(perfume.Name);
        }

        var matchingPerfumes = trie.StartsWith(searchTerm)
            .Select(name => perfumes.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            .Where(p => p != null)
            .Take(5)
            .Select(p => new { p.Id, p.Name })
            .ToList();

        return Json(matchingPerfumes);
    }
}