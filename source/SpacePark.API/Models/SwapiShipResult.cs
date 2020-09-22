using System.Text.Json.Serialization;

namespace SpacePark.API.Models
{
    public class SwapiShipResult
    {
        [JsonPropertyName("result")]
        public SwapiShip[] SwapiResult { get; set; }
    }
}
