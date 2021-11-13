using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeebsOut47.APIs
{
    public class WeatherAPI
    {
        [JsonPropertyName("coord")]
        public CoordProperty Coord { get; set; }
        [JsonPropertyName("weather")]
        public List<WeatherProp> Weather { get; set; }
        [JsonPropertyName("base")]
        public string Base { get; set; }
        [JsonPropertyName("main")]
        public MainProperty Main { get; set; }
        [JsonPropertyName("visibility")]
        public int Visibility  { get; set; }
        [JsonPropertyName("wind")]
        public WindProperty Wind { get; set; }
        [JsonPropertyName("clouds")]
        public CloudProperty Clouds { get; set; }
        [JsonPropertyName("dt")]
        public int Dt  { get; set; }
        [JsonPropertyName("sys")]
        public SysProperty Sys { get; set; }
        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("cod")]
        public int Cod { get; set; }
        [JsonIgnore]
        public int RealTimezone
        {
            get
            {
                return Timezone / 3600;
            }
        }       
        public double TimeAtEveryTimezone(long time)
        {
            return time - 3600 + Timezone;
        }
    }
}
