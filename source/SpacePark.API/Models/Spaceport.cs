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
        public Parkinglot Parkinglot { get; set; }

        public PortStatus Status { get; set; }


    }
}
