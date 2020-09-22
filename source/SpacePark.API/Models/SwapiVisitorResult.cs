using System.Text.Json.Serialization;

namespace SpacePark.API.Models
{
    public class SwapiVisitorResult
    {
        [JsonPropertyName("results")]
        public  SwapiVisitor[] SwapiResult { get; set; }
    }
}
