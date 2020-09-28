using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpacePark.API.Models;


namespace SpacePark.source.Context
{
    public class SpaceParkContext : DbContext
    {
        public DbSet<Spaceport> SpacePorts { get; set; }
        public DbSet<Parkinglot> ParkingLots { get; set; }
        public DbSet<Visitor> Visitors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true)
                .Build();

            optionsBuilder.UseSqlServer(config["ConnectionStrings:DefaultConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Spaceport>().ToTable("SpacePorts");
            builder.Entity<Spaceport>().HasKey(x=> x.SpacePortID);
            builder.Entity<Spaceport>().HasData(new {
                PortStatus = PortStatus.Open,
                
            });

            builder.Entity<Parkinglot>().ToTable("ParkingLots");
            builder.Entity<Parkinglot>().HasKey(x => x.ParkingLotID);
            builder.Entity<Parkinglot>().HasData(new {
                ParkingStatus = ParkingStatus.Available,
            },
            new {
                ParkingStatus = ParkingStatus.Available,
            },
            new {
                ParkingStatus = ParkingStatus.Available,

            },
            new {
                ParkingStatus = ParkingStatus.Available,

            },
            new {
                ParkingStatus = ParkingStatus.Available,

            });

        }
    }
}
