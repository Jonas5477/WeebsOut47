using TwitchLib.Client.Models;

namespace WeebsOut47.Commands
{
    class ColorCommand : Command
    {
        public ColorCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }
        public override void SendMessage()
        {
            WeebsOut.Client.SendMessage(ChatMessage.Channel, $"Your Color has the Hex Code {ChatMessage.ColorHex}");
        }
    }
}
