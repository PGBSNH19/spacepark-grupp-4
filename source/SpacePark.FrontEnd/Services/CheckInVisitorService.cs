using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpacePark.FrontEnd.Services
{
    public class CheckInVisitorService
    {
        public HttpClient Client { get; }

        public CheckInVisitorService(HttpClient client)
        {
            client.BaseAddress = new Uri("http://20.54.24.162:80/");
            Client = client;
        }
        public Visitor returnVisitor { get; private set; }

        public async Task<Visitor> PostVisitor(string visitorname, string shipname)
        {
            var response = await Client.GetAsync($"API/v1.0/SwapiVisitor/Character/{visitorname}");


            if (response.IsSuccessStatusCode)
            {
                var shipResponse = await Client.GetAsync($"API/v1.0/SwapiShip/Ship/{shipname}");


                if (shipResponse.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    var result = await System.Text.Json.JsonSerializer.DeserializeAsync<ArrayHandler>(responseStream);
                    returnVisitor = result.VisitorResult[0];

                    var data = new StringContent(JsonConvert.SerializeObject(returnVisitor), Encoding.UTF8, "application/json");

                    var addResponse = await Client.PostAsync($"API/v1.0/Visitor", data);

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
    public class ArrayHandler
    {
        [JsonPropertyName("results")]
        public Visitor[] VisitorResult { get; set; }
    }
    public enum HasPayed
    {
        HasPaid,
        NotPaid
    }
    public class Visitor
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("visitorID")]
        public int VisitorID { get; set; }

        public HasPayed Payed { get; set; }

        //[JsonPropertyName("shipID")]
        //public int ShipID { get; set; }

        //[JsonPropertyName("shipname")]
        //public string ShipName { get; set; }
    }

}
