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

        public DbSet<Visitorparking> VisitorParkings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true)
                .Build();

            optionsBuilder.UseSqlServer(config["ConnectionStrings:DefaultConnection"]);
        }
    }
}
