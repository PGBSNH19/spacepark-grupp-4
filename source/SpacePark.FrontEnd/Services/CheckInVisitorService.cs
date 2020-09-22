
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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

        public async Task<Visitor> PostVisitor(string visitorname, string shipname)
        {
            var response = await Client.GetAsync($"API/v1.0/SwapiVisitor/Character/{visitorname}");
            using var responseStream = await response.Content.ReadAsStreamAsync();

            if (response.IsSuccessStatusCode)
            {
                var shipResponse = await Client.GetAsync($"API/v1.0/SwapiShip/Ship/{shipname}");

                using var responseShipStream = await shipResponse.Content.ReadAsStreamAsync();
                var shipBuilder = await JsonSerializer.DeserializeAsync<Visitor>(responseShipStream);

                if (shipResponse.IsSuccessStatusCode)
                {

                    var returnVisitor = await JsonSerializer.DeserializeAsync<Visitor>(responseStream);

                    returnVisitor.ShipID = shipBuilder.ShipID;
                    returnVisitor.ShipName = shipBuilder.ShipName;

                    var data = new StringContent(returnVisitor.ToString(), Encoding.UTF8, "application/json");

                    var addResponse = await Client.PostAsync($"API/v1.0/Visitor/{returnVisitor}", data);
                    if (addResponse.IsSuccessStatusCode)
                    {
                        return returnVisitor;
                    }
                    return null;
                }
                return null;

            }

            return null;


        }

    }
    public class Visitor
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("visitorID")]
        public int VisitorID { get; set; }

        [JsonPropertyName("shipID")]
        public int ShipID { get; set; }

        [JsonPropertyName("shipname")]
        public string ShipName { get; set; }
    }

}
