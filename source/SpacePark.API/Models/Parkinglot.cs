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

        public int SpacePortID { get; set; }

        public ParkingStatus Status { get; set; }
        public int Price { get; set; }
        public int Length { get; set; }

    }
}
