using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpacePark.FrontEnd.Services
{
    public class VisitorService
    {
        public HttpClient Client { get; }
        public VisitorService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://spaceparkbackendgroup4.azurewebsites.net/");
            Client = client;
        }
        public async Task<List<Person>> GetAllTheVisitors()
        {
            var response = await Client.GetAsync("API/v1.0/visitor");
            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<Person>>(responseStream);
        }
    }

    public class Person
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("visitorID")]
        public int VisitorID { get; set; }
    }
}
