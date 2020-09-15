namespace SpacePark.API.Models
{
    public enum HasPayed
    {
        HasPaid,
        NotPaid
    }
    public class Visitor
    {
        public HasPayed Payed { get; set; }
        public string Name { get; set; }
        public int VisitorID { get; set; }
    }
}
