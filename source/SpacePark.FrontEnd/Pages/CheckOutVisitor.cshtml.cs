using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SpacePark.FrontEnd.Services;

namespace SpacePark.FrontEnd.Pages
{
    public class CheckOutVisitorModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CheckOutVisitorService _checkOutVisitorService;



        public CheckOutVisitorModel(ILogger<IndexModel> logger, CheckOutVisitorService checkOutVisitorService)
        {
            _logger = logger;
            _checkOutVisitorService = checkOutVisitorService;
        }

        //public async Task OnGetAsync()
        //{

        //}
    }
}
