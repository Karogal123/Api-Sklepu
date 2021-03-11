using System.ComponentModel.DataAnnotations;

namespace zadanie3.Data.SQL.DAO
{
    public class AutorzyPlanszowek
    {
        [Key]
        public int AutorzyPlanszowekid { get; set; }
        public int Autorid { get; set; }
        public int Planszowkaid { get; set; }
        
        public virtual Autorzy Autorzy { get; set; }
        public virtual Planszowki Planszowki { get; set; }
    }
}