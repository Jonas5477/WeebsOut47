using System;
using System.Text.Json.Serialization;

namespace WeebsOut47.APIs
{
    public class SysProperty
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("sunrise")]
        public long Sunrise { get; set; }
        [JsonPropertyName("sunset")]
        public long Sunset { get; set; }
        [JsonIgnore]
        public DateTime SunriseOkayge
        {
            get
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds(Sunrise).ToLocalTime();
                return dateTime;
            }
        }
        [JsonIgnore]
        public DateTime SunsetOkayeg
        {
            get
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds(Sunset).ToLocalTime();
                return dateTime;
            }
        }
    }
}
