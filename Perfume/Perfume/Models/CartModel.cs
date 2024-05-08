using Perfume.Constants;
using System.ComponentModel.DataAnnotations;

namespace Perfume.Models;

public class CartModel
{
    public Guid Id { get; set; }

    public string ImageSource { get; set; }

    [Display(Name = Names.Brand)]
    [Required(ErrorMessage = Messages.BrandIsMandatory)]
    public string BrandTitle { get; set; }

    [Display(Name = Names.PerfumeName)]
    [Required(ErrorMessage = Messages.NamePerfumeIsMandatory)]
    public string PerfumeTitle { get; set; }

    [Display(Name = Names.Price)]
    [Required(ErrorMessage = Messages.PriceIsMandatory)]
    public double Price { get; set; }

    [Display(Name = Names.Category)]
    [Required(ErrorMessage = Messages.CategoryIsMandatory)]
    public string Category { get; set; }

    [Display(Name = Names.Currency)]
    [Required(ErrorMessage = Messages.CurrencyIsMandatory)]
    public string Currency { get; set; }

    [Display(Name = Names.Stock)]
    [Required(ErrorMessage = Messages.StockIsMandatory)]
    public int Quantity { get; set; } = 1;


}