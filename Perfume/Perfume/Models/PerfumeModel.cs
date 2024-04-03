namespace Perfume.Models;

public class PerfumeModel
{
    public Guid Id { get; set; }

    public string ImageSource { get; set; }

    public string BrandTitle { get; set; }

    public string PerfumeTitle { get; set; }

    public int Price { get; set; }

    public string Currency { get; set; }

    public double Rating { get; set; }
}