using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SpacePark.FrontEnd.Models;

namespace SpacePark.FrontEnd.Pages
{
    public class VisitorRequestModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<VisitorRequestModel> _logger;

        public VisitorRequestModel(ILogger<VisitorRequestModel> logger, IHttpClientFactory clientFactory)
        {

            _clientFactory = clientFactory;
            _logger = logger;
        }

        public IEnumerable<VisitorsOnSite> VisitorRequest;
        public bool GetVisitorRequestError { get; set; }


        public async Task OnGet()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                    "https://localhost:5001/API/v1.0/visitor");
            request.Headers.Add("Accept", "application/visitorsonsite");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                VisitorRequest = await JsonSerializer.DeserializeAsync
                    <IEnumerable<VisitorsOnSite>>(responseStream);
            }
            else
            {
                GetVisitorRequestError = true;
                VisitorRequest = Array.Empty<VisitorsOnSite>();
            }

        }

    }
}
