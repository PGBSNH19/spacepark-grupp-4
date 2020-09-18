
namespace SpacePark.FrontEnd.Models
{
    public class VisitorsOnSite
    {

        public enum Paid
        {
            HasPaid,
            NotPaid
        }
        public string Name { get; set; }
        public int VisitorID { get; set; }

    }
}
