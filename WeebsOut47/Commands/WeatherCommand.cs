using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string message = ChatMessage.Message[1..].ToLower();
            string city = message.Split()[1];
            if (message.StartsWith("weather"))
            {               
                WeebsOut.Client.SendMessage(ChatMessage.Channel, ApiRequests.GetWeather(city));
            }
        }
    }
}
