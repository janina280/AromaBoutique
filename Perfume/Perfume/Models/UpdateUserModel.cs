﻿using System.ComponentModel.DataAnnotations;
using Perfume.Constants;

namespace Perfume.Models;

public class UpdateUserModel
{
    public Guid Id { get; set; }

    [Display(Name = Names.EmailAddress)]
    [Required(ErrorMessage = Messages.EmailAddressIsMandatory)]
    [EmailAddress(ErrorMessage = Messages.EmailAddressIsInvalid)]
    public string Email { get; set; }

    [Display(Name = Names.FirstName)]
    [Required(ErrorMessage = Messages.FirstNameIsMandatory)]
    public string FirstName { get; set; }

    [Display(Name = Names.LastName)]
    [Required(ErrorMessage = Messages.NameIsMandatory)]
    public string LastName { get; set; }

    [Display(Name = Names.PhoneNumber)]
    [Required(ErrorMessage = Messages.PhoneNumberIsMandatory)]
    [RegularExpression(Values.PhoneNumberRegex, ErrorMessage = Messages.PhoneNumberNotValidMessage)]
    public string PhoneNumber { get; set; }

    [Display(Name = Names.Image)]
    [Required(ErrorMessage = Messages.ImageIsMandatory)]
    public IFormFile ProfileImage { get; set; } = default!;
    public string ProfileImageDisplay { get; set; }
}