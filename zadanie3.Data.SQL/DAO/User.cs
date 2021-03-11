using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Zadanie3.Common.Enums;

namespace zadanie3.Data.SQL.DAO
{
    public class User
    {
        public User()
        {
            Zamowienie = new List<Zamowienia>();
        }
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        
        public virtual ICollection<Zamowienia> Zamowienie { get; set; }
       
    }
}