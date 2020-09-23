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
            client.BaseAddress = new Uri("http://20.54.24.162:80/");
            Client = client;
        }


        public async Task<HttpResponseMessage> DeleteVisitor(string visitorname)
        {
            var response = await Client.DeleteAsync($"API/v1.0/Visitor/{visitorname}");
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

    public class VisitorToDelete
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("visitorID")]
        public int VisitorID { get; set; }
    }
}
