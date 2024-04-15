using System.ComponentModel.DataAnnotations;
using Perfume.Constants;
namespace Perfume.Models
{
    public class AddPerfumeModel
    {
        [Display(Name = Names.PerfumeName)]
        [Required(ErrorMessage = Messages.NamePerfumeIsMandatory)]
        public string PerfumeName { get; set; }

        [Display(Name = Names.Brand)]
        [Required(ErrorMessage = Messages.BrandIsMandatory)]
        public string Brand { get; set; }

        [Display(Name = Names.Description)]
        [Required(ErrorMessage = Messages.DescriptionIsMandatory)]
        public string Description { get; set; }

        [Display(Name = Names.Currency)]
        [Required(ErrorMessage = Messages.CurrencyIsMandatory)]
        public string Currency { get; set; }

        [Display(Name = Names.Price)]
        [Required(ErrorMessage = Messages.PriceIsMandatory)]
        public string Price { get; set; }

        [Display(Name = Names.Image)]
        [Required(ErrorMessage = Messages.ImageIsMandatory)]
        public string Image { get; set; }

        [Range(typeof(bool), Values.BooleanTrueValue, Values.BooleanTrueValue, ErrorMessage = Messages.AcceptTermsAndConditions)]
        public bool AgreeWithTermsAndConditions { get; set; }
    }
}
