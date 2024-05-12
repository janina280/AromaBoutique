namespace Perfume.Models;

public class CartModel : Model
{
    public string ImageSource { get; set; }
    public string BrandTitle { get; set; }
    public string PerfumeTitle { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
    public string Currency { get; set; }
    public int Quantity { get; set; } = 1;
}