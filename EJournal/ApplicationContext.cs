using EJournal.Table;
using Microsoft.EntityFrameworkCore;

namespace EJournal
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Prepods> Prepod { get; set; }
        public DbSet<Students> Student { get; set; }
        public DbSet<RatingSheet> RS { get; set; }
        public DbSet<GroupNumb> GrNmb { get; set; }
        public DbSet<Subjects> Sub { get; set; }
        public DbSet<Sub_Prep> SP { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=EJournal;Username=postgres;Password=1");
        }
    }
}
