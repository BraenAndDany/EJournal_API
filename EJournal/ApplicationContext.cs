using EJournal.Table;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EJournal
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Prepods> Prepod { get; set; } = null!;
        public DbSet<Students> Student { get; set; } = null!;
        public DbSet<RatingSheet> RattingList { get; set; } = null!;
        public DbSet<GroupNumb> Group { get; set; } = null!;
        public DbSet<Subjects> Sub { get; set; } = null!;
        public DbSet<Sub_Prep> SubPrep { get; set; } = null!;
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=EJournal;Username=postgres;Password=1");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupNumb>().HasKey(x=>x.IDGroup);
            modelBuilder.Entity<Prepods>().HasKey(x => x.IDPrep);
            modelBuilder.Entity<Students>().HasKey(x => x.IDStud);
            modelBuilder.Entity<RatingSheet>().HasKey(x => x.IDList);
            modelBuilder.Entity<Sub_Prep>().HasKey(x => x.IDSubPrep);
            modelBuilder.Entity<Subjects>().HasKey(x => x.IDSub);
            modelBuilder.Entity<GroupNumb>().Property(pl => pl.IDGroup).ValueGeneratedOnAdd();
            modelBuilder.Entity<Prepods>().Property(pl => pl.IDPrep).ValueGeneratedOnAdd();
            modelBuilder.Entity<Students>().Property(pl => pl.IDStud).ValueGeneratedOnAdd();
            modelBuilder.Entity<RatingSheet>().Property(pl => pl.IDList).ValueGeneratedOnAdd();
            modelBuilder.Entity<Sub_Prep>().Property(pl => pl.IDSubPrep).ValueGeneratedOnAdd();
            modelBuilder.Entity<Subjects>().Property(pl => pl.IDSub).ValueGeneratedOnAdd();
            modelBuilder.Entity<GroupNumb>().HasOne(pr => pr.Prep).WithOne(gr => gr.Group).HasForeignKey<Prepods>(u => u.GroupID);
            modelBuilder.Entity<GroupNumb>().HasOne(pr => pr.Stud).WithOne(gr => gr.Group).HasForeignKey<Students>(u => u.GroupID);
            modelBuilder.Entity<Students>().HasOne(pr => pr.Ratings).WithOne(gr => gr.Stud).HasForeignKey<RatingSheet>(u => u.IDStud);
            modelBuilder.Entity<Sub_Prep>().HasOne(pr => pr.RatingSheet).WithOne(gr => gr.SubPrep).HasForeignKey<RatingSheet>(u => u.IDSubPrep);
            modelBuilder.Entity<Subjects>().HasOne(pr => pr.SubPrep).WithOne(gr => gr.Sub).HasForeignKey<Sub_Prep>(u => u.IDSub);
            modelBuilder.Entity<Prepods>().HasOne(pr => pr.SubPrep).WithOne(gr => gr.Prep).HasForeignKey<Sub_Prep>(u => u.IDPrep);
            modelBuilder.Entity<Sub_Prep>().HasIndex(u => u.IDSub).IsUnique(false);
            modelBuilder.Entity<Sub_Prep>().HasIndex(u => u.IDPrep).IsUnique(false);
            modelBuilder.Entity<Prepods>().HasIndex(u => u.GroupID).IsUnique(false);
            modelBuilder.Entity<Students>().HasIndex(u => u.GroupID).IsUnique(false);
            modelBuilder.Entity<RatingSheet>().HasIndex(u => u.IDStud).IsUnique(false);
            modelBuilder.Entity<RatingSheet>().HasIndex(u => u.IDSubPrep).IsUnique(false);
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
