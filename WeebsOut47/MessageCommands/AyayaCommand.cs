using System;
using TwitchLib.Client.Models;
using WeebsOut47.Commands;

namespace WeebsOut47.MessageCommands 
{
    class AyayaCommand : Command
    {
        private static long _ayaya = 0;
        public AyayaCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }

        public override void SendMessage()
        {
            if (600000 < DateTimeOffset.Now.ToUnixTimeMilliseconds() - _ayaya)
            {
                if (ChatMessage.IsModerator)
                {
                    WeebsOut.Client.SendMessage(ChatMessage.Channel, "WEEBS OUT DansGame");
                }
                else
                {
                    WeebsOut.Client.SendMessage(ChatMessage.Channel, $"/timeout {ChatMessage.Username} 10s");
                }
                _ayaya = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            }
        }
    }
}
