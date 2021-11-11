using TwitchLib.Client.Models;
using WeebsOut47.APIs;

namespace WeebsOut47.Commands
{
    class BoredCommand : Command
    {
        public BoredCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }

        public override void SendMessage()
        {
            WeebsOut.Client.SendMessage(ChatMessage.Channel, $"{ApiRequests.GetBored()}") ;
        }
    }
}
