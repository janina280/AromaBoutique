using Perfume.Constants;
using System.ComponentModel.DataAnnotations;

namespace Perfume.Models
{
    public class AddBrandModel
    {
        [Display(Name = Names.Brand)]
        [Required(ErrorMessage = Messages.BrandIsMandatory)]
        public string Brand { get; set; }

        [Display(Name = Names.Description)]
        [Required(ErrorMessage = Messages.DescriptionIsMandatory)]
        public string Description { get; set; }

        [Display(Name = Names.Image)]
        [Required(ErrorMessage = Messages.ImageIsMandatory)]
        public string Image { get; set; }
    }
}
