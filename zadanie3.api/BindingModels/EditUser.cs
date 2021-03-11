using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Zadanie3.Common.Enums;

namespace zadanie3.api.BindingModels
{
    public class EditUser
    {
        [Display(Name = "Username")]
        public string Username { get; set; }
        
        [Required]
        [Display(Name = "Username")]
        public string Name { get; set; }
        
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Display(Name = "BirthDate")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }
    }
    
    public class EditUserValidator : AbstractValidator<EditUser> {
        public EditUserValidator() {
            RuleFor(x => x.Username).NotNull();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.BirthDate).NotNull();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Gender).NotNull();
        }
    }

}