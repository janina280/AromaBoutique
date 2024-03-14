using System.ComponentModel.DataAnnotations;
using Perfume.Constants;

namespace Perfume.Models;

public class LoginModel
{
    [Display(Name = Names.EmailAddress)]
    [Required(ErrorMessage = Messages.EmailAddressIsMandatory)]
    [EmailAddress(ErrorMessage = Messages.EmailAddressIsInvalid)]
    public string Email { get; set; }

    [Display(Name = Names.Password)]
    [Required(ErrorMessage = Messages.PasswordIsMandatory)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

}