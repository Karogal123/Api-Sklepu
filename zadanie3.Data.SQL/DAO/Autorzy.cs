using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zadanie3.Data.SQL.DAO
{
    public class Autorzy
    {
        public Autorzy()
        {
            AutorPlanszowek = new List<AutorzyPlanszowek>();
        }
        
        [Key]
        public int Autorid { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public virtual ICollection<AutorzyPlanszowek> AutorPlanszowek { get; set; }
    }
    }
