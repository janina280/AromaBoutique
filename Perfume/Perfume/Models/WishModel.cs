namespace Perfume.Models;

public class WishModel
{
    public Guid Id { get; set; }

    public string ImageSource { get; set; }

    public string BrandTitle { get; set; }

    public string PerfumeTitle { get; set; }

    public double Price { get; set; }
    public string Category { get; set; }

    public string Currency { get; set; }
}