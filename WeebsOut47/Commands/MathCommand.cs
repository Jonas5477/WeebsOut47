using TwitchLib.Client.Models;
using WeebsOut47.APIs;

namespace WeebsOut47.Commands
{
    class MathCommand : Command
    {
        public MathCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }

        public override void SendMessage()
        {
            if(ChatMessage.Message.Split().Length <= 1)
            {
                WeebsOut.Client.SendMessage(ChatMessage.Channel, $"Pls use the right format {HLE.Emojis.Emoji.PointRight} §math [Calculation]");
            }
            else
            {
                string rechnung = ChatMessage.Message[(ChatMessage.Message.Split()[0].Length + 1)..];
                WeebsOut.Client.SendMessage(ChatMessage.Channel, $"{rechnung} = {ApiRequests.GetMath(rechnung)}");
            }
        }
    }
}
