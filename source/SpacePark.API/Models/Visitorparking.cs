using System;

namespace SpacePark.API.Models
{
    public class Visitorparking
    {
        public int VistorParkingID { get; set; }
        public int ParkingLotID { get; set; }
        public Parkinglot Parkinglot { get; set; }
        public int VisitorID { get; set; }
        public Visitor Vistor { get; set; }
        public DateTime DateOfEntry { get; set; }


    }
}
