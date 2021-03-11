using System;
using Zadanie3.Common.Enums;


namespace zadanie3.api.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }

    }
}