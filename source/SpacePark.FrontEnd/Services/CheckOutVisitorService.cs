using System;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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


        public async Task<Visitor> DeleteVisitor(string visitorname)
        {
            return null;
        }
    }

    public class VisitorToDelete
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("visitorID")]
        public int VisitorID { get; set; }
    }
}
