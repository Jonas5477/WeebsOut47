using System;
using System.Text.Json.Serialization;
using WeebsOut47.Utilities;

namespace WeebsOut47.APIs
{
    public class MainProperty
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }
        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }
        [JsonPropertyName("temp_min")]
        public double TempMin { get; set; }
        [JsonPropertyName("temp_max")]
        public double TempMax { get; set; }
        [JsonPropertyName("pressure")]                      //hPa
        public int Pressure { get; set; }
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
        [JsonIgnore]
        public double CTemp => Math.Round(Rechner.KelvinToCelcius(Temp),2);
        [JsonIgnore]
        public double CFeelsLike => Math.Round(Rechner.KelvinToCelcius(FeelsLike),2);
    }
}
