namespace Perfume.Models;

public class NavigationBarBrandsModel
{
    public List<BrandModel> MenBrands { get; set; } = new List<BrandModel>();

    public List<BrandModel> WomenBrands { get; set; } = new List<BrandModel>();

    public List<BrandModel> BestSellsBrands { get; set; } = new List<BrandModel>();

    public List<BrandModel> UnisexBrands { get; set; } =  new List<BrandModel>();
}