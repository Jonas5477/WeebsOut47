using System.Text.Json.Serialization;

namespace WeebsOut47.APIs
{
    public class CloudProperty
    {
        [JsonPropertyName("all")]                           // in %
        public int All { get; set; }
    }
}
