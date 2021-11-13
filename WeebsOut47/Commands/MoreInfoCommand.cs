using System;
using System.Text.RegularExpressions;
using TwitchLib.Client.Models;
using WeebsOut47.APIs;
using WeebsOut47.Utilities;

namespace WeebsOut47.Commands
{
    public class MoreInfoCommand : Command
    {
        public MoreInfoCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }
        public override void SendMessage()
        {
            if (ChatMessage.Message.Split().Length <= 1)
            {
                WeebsOut.Client.SendMessage(ChatMessage.Channel, $"You have to use this format {HLE.Emojis.Emoji.PointRight} §weather [cityname] ");
            }
            else
            {
                string message = ChatMessage.GetMessage()[1..].ToLower();
                string name = message.Split()[1];

                if (Regex.IsMatch(name, @"^(?i)[\wüößä\-',.\s-]+$"))
                {
                    WeatherAPI weatherAPI = ApiRequests.GetWeather(name);
                    if (weatherAPI == null)
                    {
                        WeebsOut.Client.SendMessage(ChatMessage.Channel, $"Unlucky THIS city doesnt exist :(");
                    }
                    else
                    {
                        double now = weatherAPI.TimeAtEveryTimezone(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                        dateTime = dateTime.AddSeconds(now).ToLocalTime();
                        Console.WriteLine(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                        Console.WriteLine(now);
                        Console.WriteLine(dateTime);
                        WeebsOut.Client.SendMessage(ChatMessage.Channel, $"Cityname: {weatherAPI.Name} || Country: {weatherAPI.Sys.Country} || Current Time: {dateTime:HH:mm:ss} || Timezone: GMT+{weatherAPI.RealTimezone} || Temperature: {weatherAPI.Main.CTemp}°C || Pressure: {weatherAPI.Main.Pressure}hPa || Humidity: {weatherAPI.Main.Humidity}% || Clouds: {weatherAPI.Clouds.All}% || Sunrise: {weatherAPI.Sys.SunriseOkayge:HH:mm} Uhr || Sunset: {weatherAPI.Sys.SunsetOkayeg:HH:mm} Uhr");
                    }
                }
                else
                {
                    WeebsOut.Client.SendMessage(ChatMessage.Channel, $" Pls use a real cityname :)");
                }
            }
        }
    }
}
