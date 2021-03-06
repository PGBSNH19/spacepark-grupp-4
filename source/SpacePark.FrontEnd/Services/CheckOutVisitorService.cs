﻿using Newtonsoft.Json;
using System;
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
            client.BaseAddress = new Uri("https://spaceparkbackendgroup4.azurewebsites.net/");
            Client = client;
        }
        public async Task<HttpResponseMessage> DeleteVisitor(int id)
        {
            var visitorData = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
            var putVisitorResponse = await Client.PutAsync($"API/v1.0/ParkingLot/Checkout/{id}", visitorData);

            if (putVisitorResponse.IsSuccessStatusCode)
                return putVisitorResponse;
            else
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
