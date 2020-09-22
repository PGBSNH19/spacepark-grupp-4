using System.Text.Json.Serialization;

namespace SpacePark.API.Models
{
    public class SwapiShip
    {
        [JsonPropertyName("name")]
        public string ShipName { get; set; }
    }
}
