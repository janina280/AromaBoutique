using Perfume.Constants;
using System.ComponentModel.DataAnnotations;

namespace Perfume.Models;

public class PerfumeModel
{
    public Guid Id { get; set; }

    [Display(Name = Names.Image)]
    [Required(ErrorMessage = Messages.ImageIsMandatory)]

    public IFormFile ImageSource { get; set; }

    public string BrandTitle { get; set; }

    public string PerfumeTitle { get; set; }

    public int Price { get; set; }

    public string Currency { get; set; }

    public double Rating { get; set; }
    public string DisplayImage { get; set; }
}