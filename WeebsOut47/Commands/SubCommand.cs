using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client.Models;

namespace WeebsOut47.Commands
{
    class SubCommand : Command
    {
        public SubCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }

        public override void SendMessage()
        {
            if (ChatMessage.IsSubscriber)
            {
                WeebsOut.Client.SendMessage(ChatMessage.Channel, $"{ChatMessage.Username} is currently subscribing and has subcribed for {ChatMessage.SubscribedMonthCount} Months FeelsGoodMan");
            }
            else
            {
                WeebsOut.Client.SendMessage(ChatMessage.Channel, $"DansGame {ChatMessage.Username} isn't subscribing at the moment DansGame total months subscribed: {ChatMessage.SubscribedMonthCount} FeelsWeirdMan");
            }
        }
    }
}
