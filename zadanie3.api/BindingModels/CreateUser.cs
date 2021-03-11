using System;
using System.ComponentModel.DataAnnotations;
using Zadanie3.Common.Enums;


namespace zadanie3.api.BindingModels
{
    public class CreateUser
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }
        
        [Required]
        [Display(Name = "BirthDate")]
        public DateTime BirthDate { get; set; }
    }
}