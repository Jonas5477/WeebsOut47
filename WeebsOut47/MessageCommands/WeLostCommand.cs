using System;
using TwitchLib.Client.Models;
using WeebsOut47.Commands;

namespace WeebsOut47.MessageCommands
{
    class WeLostCommand : Command
    {
        private static long _user = 0;
        public WeLostCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }

        public override void SendMessage()
        {
            if (60000000 < DateTimeOffset.Now.ToUnixTimeMilliseconds() - _user)
            {
                WeebsOut.Client.SendMessage(ChatMessage.Channel, $"We lost {ChatMessage.Username} PepeHands");
                _user = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            }
        }
    }
}
