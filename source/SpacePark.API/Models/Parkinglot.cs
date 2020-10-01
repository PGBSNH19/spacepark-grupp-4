
namespace SpacePark.API.Models
{
    public enum ParkingStatus
    {
        Available,
        Occupied
    }
    public class Parkinglot
    {
        public int ParkingLotID { get; set; }
        public ParkingStatus Status { get; set; }
        public int? VisitorID {get; set;}
        public Visitor Visitor { get; set; }
        public int SpaceportID { get; set; }
        public Spaceport Spaceport { get; set; }
    }
}
