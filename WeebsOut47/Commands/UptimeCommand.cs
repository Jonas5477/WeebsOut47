using System;
using TwitchLib.Client.Models;

namespace WeebsOut47.Commands
{
    class UptimeCommand : Command
    {
        public UptimeCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }
        public override void SendMessage()
        {           
            WeebsOut.Client.SendMessage(ChatMessage.Channel, Bot.Uptime().ToString());
        }
    }
}
