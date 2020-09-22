using Microsoft.AspNetCore.Mvc.RazorPages;
using SpacePark.FrontEnd.Services;
using System.Threading.Tasks;

namespace SpacePark.FrontEnd.Pages
{
    public class CheckInVisitorModel : PageModel
    {

        private readonly CheckInVisitorService _checkInVisitorService;

        public Visitor visitor { get; private set; }

        public CheckInVisitorModel(CheckInVisitorService checkInVisitorService)
        {

            _checkInVisitorService = checkInVisitorService;
        }

        public async Task OnPost()
        {
            string visitorname = Request.Form["visitorname"];
            string shipname = Request.Form["shipname"];

            var response = _checkInVisitorService.PostVisitor(visitorname, shipname);

            if (response != null)
            {
                visitor = new Visitor
                {
                    Name = response.Result.Name,
                    //ShipID = response.Result.ShipID,
                    //ShipName = response.Result.ShipName,
                    VisitorID = response.Result.VisitorID
                };
            }
            else
            {
                visitor = null;
            }


        }
    }
}
