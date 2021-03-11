using System.ComponentModel.DataAnnotations;

namespace zadanie3.Data.SQL.DAO
{
    public class ZamowieniaPlanszowek
    {
        [Key]
        public int ZamowieniaPlanszowekid { get; set; }
        public int Planszowkaid { get; set; }
        public int Zamowienieid { get; set; }
        
        public virtual Zamowienia Zamowienia { get; set; }
        public virtual Planszowki Planszowki { get; set; }
    }
}