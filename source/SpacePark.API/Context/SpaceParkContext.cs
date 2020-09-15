using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpacePark.source.SpacePark.API.Models;
using System.IO;


namespace SpacePark.source.Context
{
    public class SpaceParkContext : DbContext
    {
      public DbSet<SpacePort> SpacePorts { get; set: }      
      
      public DbSet<ParkingLot> ParkingLots { get; set: }      

      public DbSet<Visitor> Visitors { get; set: }      

      public DbSet<VisitorParking> VisitorParkings { get; set: }      

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
          IConfiguration config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", true)
              .Build();

        optionsBuilder.UseSqlServer(config["ConnectionStrings:DefaultConnection"]);
      }
    }
}
