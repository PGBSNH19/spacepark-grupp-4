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
            client.BaseAddress = new Uri("https://localhost:5001/");
            Client = client;
        }
        //ublic Visitor returnVisitor { get; private set; }

        public async Task<Visitor> PostVisitor(string visitorname, string shipname)
        {

            var checkresponse = await Client.GetAsync($"API/v1.0/ParkingLot/Check");
            if (checkresponse.IsSuccessStatusCode)
            {
                var response = await Client.GetAsync($"API/v1.0/SwapiVisitor/Character/{visitorname}");


                if (response.IsSuccessStatusCode)
                {
                    var shipResponse = await Client.GetAsync($"API/v1.0/SwapiShip/Ship/{shipname}");

                    if (shipResponse != null)
                    {
                        Visitor returnVisitor = new Visitor();
                        returnVisitor.Name = visitorname;

                        var data = new StringContent(JsonConvert.SerializeObject(returnVisitor), Encoding.UTF8, "application/json");

                        var visitorResponse = await Client.PostAsync($"API/v1.0/Visitor", data);

                        using var visitorResponseStream = await visitorResponse.Content.ReadAsStreamAsync();
                        var visitorResult = await System.Text.Json.JsonSerializer.DeserializeAsync<Visitor>(visitorResponseStream);

                        if (visitorResponse.IsSuccessStatusCode)
                        {
                            var checkinData = new StringContent(JsonConvert.SerializeObject(visitorResult), Encoding.UTF8, "application/json");

                            var checkin = await Client.PutAsync($"API/v1.0/Parkinglot/Checkin", checkinData);
                            if (checkin.IsSuccessStatusCode)
                            {
                                return visitorResult;
                            }
                        }
                        return null;
                    }

                }
            }

            return null;


        }

    }
    public class ArrayHandler
    {
        [JsonPropertyName("results")]
        public Visitor[] VisitorResult { get; set; }
    }

    public class Visitor
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public int VisitorID { get; set; }
    }

}
