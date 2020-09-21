using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SpacePark.FrontEnd.Services;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpacePark.FrontEnd.Pages
{
    public class CheckInVisitorModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CheckInVisitorService _checkInVisitorService;
        public HttpResponseMessage response { get; private set; }
        public CheckInVisitorModel(ILogger<IndexModel> logger, CheckInVisitorService checkInVisitorService)
        {
            _logger = logger;
            _checkInVisitorService = checkInVisitorService;
        }

        public async Task OnPost()
        {
            string name = Request.Form["name"];

            //return response = await _checkInVisitorService.PostVisitor(name);

        }









    }
}
