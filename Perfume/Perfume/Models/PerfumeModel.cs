using DataBaseLayout.Models;

namespace Perfume.Models;

public class PerfumeModel
{
    public Guid Id { get; set; }

    public string BrandTitle { get; set; }

    public string PerfumeTitle { get; set; }

    public int Price { get; set; }

    public string Currency { get; set; }

    public double Rating { get; set; }
    public string DisplayImage { get; set; }
    public string Description { get; set; }

    public PerfumeCategory PerfumeCategory { get; set; }


}