using System;
using System.Text.Json.Serialization;

namespace SpacePark.API.Models
{
    public class SwapiVisitor
    {
        [JsonPropertyName("name")]
        public string CharachterName { get; set; }
    }
}
