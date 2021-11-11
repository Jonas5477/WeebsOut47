using System.Text.RegularExpressions;
using TwitchLib.Client.Models;
using WeebsOut47.APIs;
using WeebsOut47.Utilities;

namespace WeebsOut47.Commands
{
    class WeatherCommand : Command
    {
        public WeatherCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
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
                    if ( weatherAPI == null)
                    {
                        WeebsOut.Client.SendMessage(ChatMessage.Channel, $"Unlucky THIS city doesnt exist :(");                   
                    }
                    else
                    {
                        WeebsOut.Client.SendMessage(ChatMessage.Channel, $"{weatherAPI.Sys.SunsetOkayeg}");
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
