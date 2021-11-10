using TwitchLib.Client.Models;

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
