using System.ComponentModel.DataAnnotations;
using Perfume.Constants;
namespace Perfume.Models;

public class AddPerfumeModel
{
    [Display(Name = Names.PerfumeName)]
    [Required(ErrorMessage = Messages.NamePerfumeIsMandatory)]
    public string PerfumeName { get; set; }

    [Display(Name = Names.Category)]
    [Required(ErrorMessage = Messages.CategoryIsMandatory)]
    public string Category { get; set; }

    [Display(Name = Names.Brand)]
    [Required(ErrorMessage = Messages.BrandIsMandatory)]
    public string Brand { get; set; }

    [Display(Name = Names.Stock)]
    [Required(ErrorMessage = Messages.StockIsMandatory)]
    public int Stock { get; set; }

    [Display(Name = Names.Description)]
    [Required(ErrorMessage = Messages.DescriptionIsMandatory)]
    public string Description { get; set; }

    [Display(Name = Names.Currency)]
    [Required(ErrorMessage = Messages.CurrencyIsMandatory)]
    public string Currency { get; set; }

    [Display(Name = Names.Price)]
    [Required(ErrorMessage = Messages.PriceIsMandatory)]
    public int Price { get; set; }

    [Display(Name = Names.Image)]
    [Required(ErrorMessage = Messages.ImageIsMandatory)]
    public IFormFile Image { get; set; }
}