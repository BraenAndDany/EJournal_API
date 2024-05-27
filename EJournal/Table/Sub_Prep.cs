namespace EJournal.Table
{
    public class Sub_Prep
    {
        public int IDSubPrep { get; set; }
        public int? IDSub { get; set; }
        public Subjects? Sub { get;set; }
        public int? IDPrep { get; set; }
        public Prepods? Prep { get; set;}
        public RatingSheet? RatingSheet { get; set; }
    }
}
