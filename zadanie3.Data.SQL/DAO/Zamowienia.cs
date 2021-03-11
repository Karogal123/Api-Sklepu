using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zadanie3.Data.SQL.DAO
{
    public class Zamowienia
    {
        public Zamowienia()
        {
            ZamowieniePlanszowek = new List<ZamowieniaPlanszowek>();
        }
        [Key]
        public int Zamowienieid { get; set; }
        public int Uzytkownikid { get; set; }
        public DateTime DataZlozeniaZamowienia { get; set; }
        
        public virtual ICollection<ZamowieniaPlanszowek> ZamowieniePlanszowek { get; set; }
        public virtual User User { get; set; }
    }
}