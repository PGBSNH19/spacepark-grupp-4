using System;
using System.Net.Http;

namespace SpacePark.FrontEnd.Services
{
    public class CheckOutVisitorService
    {
        public HttpClient Client { get; }

        public CheckOutVisitorService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:5001");
            Client = client;
        }

    }
}
