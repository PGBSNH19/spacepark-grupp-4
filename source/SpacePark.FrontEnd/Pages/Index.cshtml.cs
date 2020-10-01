using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SpacePark.FrontEnd.Services;
using System.Collections.Generic;

namespace SpacePark.FrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Person> Visitors { get; private set; }
        public IndexModel(ILogger<IndexModel> logger, VisitorService visitorService)
        {
            _logger = logger;
        }
    }
}
