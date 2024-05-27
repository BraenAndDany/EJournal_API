namespace EJournal.Table
{
    public class RatingSheet
    {
        public int IDList {  get; set; }
        public int? IDStud { get; set; }
        public Students? Stud {  get; set; }
        public int? IDSubPrep { get; set; }
        public Sub_Prep? SubPrep {  get; set; }
        public string? JsonList { get; set; }
    }
}
