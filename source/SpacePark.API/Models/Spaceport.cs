using System.Collections.Generic;
using System.Linq;
using SpacePark.source.Context;

namespace SpacePark.API.Models
{
    public enum PortStatus
    {
        Open,
        Closed
    }
    public class Spaceport
    {
        public int SpacePortID { get; set; }
        //public Parkinglot Parkinglot { get; set; }
        public PortStatus Status { get; set; }
        //public int ParkingSpaces { get; set; }
        public Parkinglot[] Parkinglots { get; set; }

        public Spaceport CreateSpacePort(SpaceParkContext context)
        {
            var spacePortData = context.SpacePorts.FirstOrDefault();
            var spacePort = new Spaceport
            {
                Parkinglots = new Parkinglot[5],
                Status = PortStatus.Open
            };
            if(spacePortData == null)
            {
                context.SpacePorts.Add(spacePort);
                context.SaveChangesAsync();
            }
            return spacePortData;
        }

    }
}
