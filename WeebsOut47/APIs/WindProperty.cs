using System.Text.Json.Serialization;

namespace WeebsOut47.APIs
{
    public class WindProperty
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }               // in m/s
        [JsonPropertyName("deg")]
        public int Deg { get; set; }
        [JsonPropertyName("gust")]
        public double Gust { get; set; }
        [JsonIgnore]
        public string Direction
        {
            get
            {
                if(Deg < 23)
                {
                    return $"south";
                }
                else if(Deg < 68)
                {
                    return $"south-west";
                }
                else if(Deg < 113)
                {
                    return $"west";
                }
                else if(Deg < 158)
                {
                    return $"north-west";
                }
                else if (Deg < 202)
                {
                    return $"north";
                }
                else if (Deg < 247)
                {
                    return $"north-east";
                }
                else if (Deg < 292)
                {
                    return $"east";
                }
                else if (Deg < 337)
                {
                    return $"south-east";
                }
                else if (Deg < 360)
                {
                    return $"north";
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
