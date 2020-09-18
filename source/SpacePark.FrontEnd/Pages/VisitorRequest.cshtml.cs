using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SpacePark.FrontEnd.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpacePark.FrontEnd.Pages
{
    public class VisitorRequestModel : PageModel
    {

        private readonly ILogger<VisitorRequestModel> _logger;
        private readonly VisitorService _visitorService;


        public List<Person> Visitors { get; private set; }
        public VisitorRequestModel(ILogger<VisitorRequestModel> logger, VisitorService visitorService)
        {
            _logger = logger;
            _visitorService = visitorService;
        }

        public async Task OnGet()
        {

            Visitors = await _visitorService.GetAllTheVisitors();

        }

    }
}
