using System.Text.Json.Serialization;

namespace WeebsOut47.APIs
{
    public class WeatherProp
    {
        [JsonPropertyName("main")]
        public string Main { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }
}
