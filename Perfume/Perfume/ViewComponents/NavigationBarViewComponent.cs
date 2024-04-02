using Microsoft.AspNetCore.Mvc;
using Perfume.Models;

namespace Perfume.ViewComponents;

[ViewComponent]
public class NavigationBarViewComponent : ViewComponent
{
    public Task<IViewComponentResult> InvokeAsync()
    {
        var mock = new NavigationBarBrandsModel();
        mock.MenBrands.Add(new BrandModel() { Name = "Armani" });

        //return View("NavigationBar", mock);
    }
}