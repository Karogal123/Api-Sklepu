using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zadanie3.Data.SQL.DAO
{
    public class Planszowki
    {
        public Planszowki()
        {
            AutorPlanszowek = new List<AutorzyPlanszowek>();
            ZamowieniePlanszowek = new List<ZamowieniaPlanszowek>();
        }
        [Key]
        public int Planszowkaid { get; set; }
        public string Nazwa { get; set; }
        public string Typ { get; set; }
        public string IloscGraczy { get; set; }
        public int Cena { get; set; }
        public string CzasGry { get; set; }
        public string Wiek { get; set; }
        public string Wydanie { get; set; }
        
        public virtual ICollection<AutorzyPlanszowek> AutorPlanszowek { get; set; }
        public virtual ICollection<ZamowieniaPlanszowek> ZamowieniePlanszowek { get; set; }
        
    }
}