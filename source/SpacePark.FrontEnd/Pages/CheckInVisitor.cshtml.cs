using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SpacePark.FrontEnd.Services;
using System.Threading.Tasks;

namespace SpacePark.FrontEnd.Pages
{
    public class CheckInVisitorModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CheckInVisitorService _checkInVisitorService;
        public Visitor response { get; private set; }

        public CheckInVisitorModel(ILogger<IndexModel> logger, CheckInVisitorService checkInVisitorService)
        {
            _logger = logger;
            _checkInVisitorService = checkInVisitorService;
        }

        public async Task<Visitor> OnPost()
        {
            string visitorname = Request.Form["visitorname"];
            string shipname = Request.Form["shipname"];

            var response = await _checkInVisitorService.PostVisitor(visitorname, shipname);
            if (response != null)
            {
                return response;
            }
            return null;
        }
    }
}
