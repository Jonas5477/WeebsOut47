using TwitchLib.Client.Models;

namespace WeebsOut47.Commands
{
    public class WikiCommand : Command
    {
        public WikiCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }

        public override void SendMessage()
        {
            string search = ChatMessage.Message[(ChatMessage.Message.Split()[0].Length + 1)..];
            WeebsOut.Client.SendMessage(ChatMessage.Channel, $"{ApiRequests.GetSearch(search)}");
        }
    }
}
