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
                
                Status = PortStatus.Open,
                SpacePortID = 1
                
            });

            builder.Entity<Parkinglot>().ToTable("ParkingLots");
            builder.Entity<Parkinglot>().HasKey(x => x.ParkingLotID);
            builder.Entity<Parkinglot>().HasData(new {
                Status = ParkingStatus.Available,
                ParkingLotID = 1,
                SpaceportID = 1
            },
            new {
                Status = ParkingStatus.Available,
                ParkingLotID = 2,
                SpaceportID = 1
            },
            new {
                Status = ParkingStatus.Available,
                ParkingLotID = 3,
                SpaceportID = 1
            },
            new {
                Status = ParkingStatus.Available,
                ParkingLotID = 4,
                SpaceportID = 1
            },
            new {
                Status = ParkingStatus.Available,
                ParkingLotID = 5,
                SpaceportID = 1
            });

        }
    }
}
