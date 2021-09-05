using TwitchLib.Client.Models;

namespace WeebsOut47.Commands
{
    class PingCommand : Command
    {
        public PingCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }

        public override void SendMessage()
        {
            WeebsOut.Client.SendMessage(ChatMessage.Channel, "DansGame ");
        }
    }
}
