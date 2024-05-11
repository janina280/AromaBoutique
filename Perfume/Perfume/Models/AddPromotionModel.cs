using Perfume.Constants;
using System.ComponentModel.DataAnnotations;

namespace Perfume.Models
{
    public class AddPromotionModel
    {

        [Display(Name = Names.Description)]
        [Required(ErrorMessage = Messages.DescriptionIsMandatory)]
        public string Description { get; set; }

        [Display(Name = Names.Image)]
        [Required(ErrorMessage = Messages.ImageIsMandatory)]
        public IFormFile Image { get; set; }

    }
}
