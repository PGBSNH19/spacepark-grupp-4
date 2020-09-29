using Newtonsoft.Json;
using System;
using System.Linq;
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

                        var visitorToCreate = await Client.PostAsync($"API/v1.0/Visitor", data);



                        if (visitorToCreate.IsSuccessStatusCode)
                        {
                            var visitorResponse = await Client.GetAsync($"API/v1.0/Visitor/Add");

                            using var responseStream = await visitorResponse.Content.ReadAsStreamAsync();

                            var result = await System.Text.Json.JsonSerializer.DeserializeAsync<Visitor[]>(responseStream);



                            Visitor putVisitor = new Visitor();

                            putVisitor = result.Where(x => x.Name == visitorname).Last();

                            var visitorData = new StringContent(JsonConvert.SerializeObject(putVisitor), Encoding.UTF8, "application/json");
                            if (visitorResponse.IsSuccessStatusCode)
                            {
                                var checkinResponse = await Client.PutAsync($"API/v1.0/ParkingLot/Checkin", visitorData);
                                if (checkinResponse.IsSuccessStatusCode)
                                {
                                    return putVisitor;
                                }
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

    public class ArrayHandlerDB
    {
        public Visitor[] VisitorDBResult { get; set; }
    }

    public class Visitor
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("visitorID")]
        public int VisitorID { get; set; }
    }

}
