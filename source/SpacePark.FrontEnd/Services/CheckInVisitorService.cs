using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpacePark.FrontEnd.Services
{
    public class CheckInVisitorService
    {
        public HttpClient Client { get; }

        public CheckInVisitorService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:5001/");
            Client = client;
        }

        public async Task<HttpResponseMessage> PostVisitor(string name)
        {
            var response = await Client.GetAsync($"API/v1.0//{name}");

            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            else
            {
                return null;
            }


        }

    }
}
