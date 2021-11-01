using System;
using TwitchLib.Client.Models;

namespace WeebsOut47.Commands
{
    class MathCommand : Command
    {
        public MathCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }

        public override void SendMessage()
        {
            string rechnung = ChatMessage.Message[(ChatMessage.Message.Split()[0].Length + 1)..];
            WeebsOut.Client.SendMessage(ChatMessage.Channel, $"{rechnung} = {ApiRequests.GetMath(rechnung)}");
        }
    }
}
