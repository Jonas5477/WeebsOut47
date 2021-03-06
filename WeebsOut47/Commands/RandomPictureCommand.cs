using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client.Models;
using WeebsOut47.APIs;

namespace WeebsOut47.Commands
{
    class RandomPictureCommand : Command
    {
        public RandomPictureCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }

        public override void SendMessage()
        {
            WeebsOut.Client.SendMessage(ChatMessage.Channel, $"{ApiRequests.GetRandomFox()}");
        }
    }
}
