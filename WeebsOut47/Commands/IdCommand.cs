
using TwitchLib.Client.Models;

namespace WeebsOut47.Commands
{
    class IdCommand : Command
    {
        public IdCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }

        public override void SendMessage()
        {
            WeebsOut.Client.SendMessage(ChatMessage.Channel, $"Your ID is {ChatMessage.UserId} and the ID of this Chat Room is {ChatMessage.RoomId} FeelsOkayMan");
        }
    }
}
