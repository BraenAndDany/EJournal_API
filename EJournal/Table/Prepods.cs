using System.ComponentModel.DataAnnotations.Schema;

namespace EJournal.Table
{
    public class Prepods
    {
        public int IDPrep {  get; set; }
        public string? FIO { get; set;}
        public int? GroupID { get; set; }
        public GroupNumb? Group {  get; set; }
        public Sub_Prep? SubPrep { get; set; }
        public string? Login {  get; set; }
        public string? Password { get; set; }

        
    }
}
