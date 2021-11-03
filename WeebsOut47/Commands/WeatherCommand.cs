using System.Text.RegularExpressions;
using TwitchLib.Client.Models;

namespace WeebsOut47.Commands
{
    class WeatherCommand : Command
    {
        public WeatherCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }
        public override void SendMessage()
        {
            if (ChatMessage.Message.Length < 9)
            {
                WeebsOut.Client.SendMessage(ChatMessage.Channel, $"You have to use this format {HLE.Emojis.Emoji.PointRight} §weather [cityname] ");
            }
            else
            {
                string message = ChatMessage.Message[1..].ToLower();
                string city = message.Split()[1];                    

                if (Regex.IsMatch(city, @"^(?i)[\wüößä\-',.\s-]+$"))
                {
                    WeebsOut.Client.SendMessage(ChatMessage.Channel, ApiRequests.GetWeather(city));                   
                }
                else
                {
                    WeebsOut.Client.SendMessage(ChatMessage.Channel, $" Pls use a real cityname :)");
                }
            }
        }
    }
}
