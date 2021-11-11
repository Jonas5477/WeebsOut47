using System.Text.Json.Serialization;

namespace WeebsOut47.APIs
{
    public class CoordProperty
    {
        [JsonPropertyName("lon")]
        public double Lon { get; set; }
        [JsonPropertyName("lat")]
        public double Lat { get; set; }
    }
}
