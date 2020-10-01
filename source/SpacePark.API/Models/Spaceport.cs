using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpacePark.API.Models
{
    public enum PortStatus
    {
        Open,
        Closed
    }
    public class Spaceport
    {
        [Key]
        public int SpacePortID { get; set; }
        public PortStatus Status { get; set; }
        public ICollection<Parkinglot> Parkinglots { get; set; }
    }
}
