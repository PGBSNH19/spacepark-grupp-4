using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
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


        public async Task<HttpResponseMessage> DeleteVisitor(int id)
        {

            var visitorResponse = await Client.GetAsync($"API/v1.0/Visitor/Add");

            if (visitorResponse.IsSuccessStatusCode)
            {

                using var responseStream = await visitorResponse.Content.ReadAsStreamAsync();

                var result = await System.Text.Json.JsonSerializer.DeserializeAsync<Visitor[]>(responseStream);

                Visitor putVisitor = new Visitor();

                putVisitor = result.Where(x => x.VisitorID == id).FirstOrDefault();

                var visitorData = new StringContent(JsonConvert.SerializeObject(putVisitor), Encoding.UTF8, "application/json");

                var putVisitorResponse = await Client.PutAsync($"API/v1.0/ParkingLot/Checkout", visitorData);


                if (putVisitorResponse.IsSuccessStatusCode)
                {
                    return putVisitorResponse;
                }
            }
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
