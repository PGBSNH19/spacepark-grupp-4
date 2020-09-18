using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace SpacePark.FrontEnd.Pages
{
    public class VisitorRequestModel : PageModel
    {

        private readonly ILogger<VisitorRequestModel> _logger;

        public string JsonResponseFromAPI { get; set; }
        public VisitorRequestModel(ILogger<VisitorRequestModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

            var client = new RestClient($"https://localhost:5001/API/v1.0/");
            var request = new RestRequest($"visitor", Method.GET);
            IRestResponse apiResponse = client.Execute(request);
            var result = apiResponse.Content;

            JsonResponseFromAPI = result;
            //return new OkResult();
        }

    }
}
