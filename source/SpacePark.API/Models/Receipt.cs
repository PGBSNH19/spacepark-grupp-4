using System;

namespace SpacePark.API.Models
{
    public class Receipt
    {
        public int SpaceCredit { get; set; }
        public int VisitorID { get; set; }
        public DateTime Date { get; set; }
        public int ReceiptID { get; set; }
    }
}
