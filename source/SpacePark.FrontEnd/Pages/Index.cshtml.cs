using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SpaceParkFE.Services;

namespace SpacePark.FrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly VisitorService _visitorService;
        public List<Person> Visitors { get; private set; }


        public IndexModel(ILogger<IndexModel> logger, VisitorService visitorService)
        {
            _logger = logger;
            _visitorService = visitorService;
        }

        public async Task OnGetAsync()
        {
            Visitors = await _visitorService.GetAllTheVisitors();
        }
    }
}
