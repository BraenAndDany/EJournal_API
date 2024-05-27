namespace EJournal.Table
{
    public class Students
    {
        public int IDStud {  get; set; }
        public string? FIO { get; set;}
        public int? GroupID { get; set; }
        public GroupNumb? Group { get; set;}
        public RatingSheet? Ratings { get; set; }
        public string? Login { get; set;}
        public string? Password { get; set;}

    }
}
