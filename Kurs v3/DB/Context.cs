using Kurs_v3.DB.Model;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
namespace Kurs_v3.DB
{
    public class Context: DbContext
    {
        public DbSet<Plate> Plates { get; set; }
        public DbSet<Dial> Dials { get; set; }
        public DbSet<Display> Displays { get; set; }
        public DbSet<Assembly> Assemblies { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Position> Positions { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["Home"].ConnectionString);
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Position>()
                .HasData(new List<Position>()
                {
                    new Position { Id = 1, NameOfPosition = "Админ"},
                    new Position { Id = 2, NameOfPosition = "Секретарь"},
                    new Position { Id = 3, NameOfPosition = "Конструктор"},
                    new Position { Id = 4, NameOfPosition = "Сборщик"}
                });

            modelBuilder
                .Entity<Users>()
                .HasData(new List<Users>()
                {
                    new Users { Id = 1, Name = "Admin", Surname = "Admin", Login = "Admin", Password = "Admin",Patronymic = "" ,Position = 1}
                });

            modelBuilder
               .Entity<Dial>()
               .HasData(new List<Dial>()
               {
                    new Dial {Id = 1, Name = "None", SerialNumber = "-", Description = "", Cost = 0 }
               });

            modelBuilder
              .Entity<Display>()
              .HasData(new List<Display>()
              {
                    new Display {Id = 1, Name = "None", SerialNumber = "-", Description = "", Cost = 0 }
              });

            modelBuilder
              .Entity<Plate>()
              .HasData(new List<Plate>()
              {
                    new Plate {Id = 1, Name = "None", SerialNumber = "-", Description = "", Cost = 0 }
              });
        }
    }
}
