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
        public PortStatus Status { get; set; }
        public Parkinglot[] Parkinglots { get; set; }

    }
}
