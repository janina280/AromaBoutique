using System.ComponentModel.DataAnnotations;
using Perfume.Constants;

namespace Perfume.Models;

public class BrandModel
{
    [Display(Name = Names.Brand)]
    [Required(ErrorMessage = Messages.BrandIsMandatory)]
    public string Name { get; set; }

    [Display(Name = Names.Description)]
    [Required(ErrorMessage = Messages.DescriptionIsMandatory)]
    public string Description { get; set; }

    [Display(Name = Names.Image)]
    [Required(ErrorMessage = Messages.ImageIsMandatory)]
    public string Image { get; set; }
    public string ImageDisplay { get; set; }

}