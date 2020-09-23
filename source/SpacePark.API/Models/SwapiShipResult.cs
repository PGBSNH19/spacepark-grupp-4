using System.Text.Json.Serialization;

namespace SpacePark.API.Models
{
    public class SwapiShipResult
    {
        [JsonPropertyName("results")]
        public SwapiShip[] SwapiResult { get; set; }
    }
}
