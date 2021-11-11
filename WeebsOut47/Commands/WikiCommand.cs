using TwitchLib.Client.Models;
using WeebsOut47.APIs;

namespace WeebsOut47.Commands
{
    public class WikiCommand : Command
    {
        public WikiCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }

        public override void SendMessage()
        {
            if (ChatMessage.Message.Split().Length >= 2)
            {
                string search = ChatMessage.Message[(ChatMessage.Message.Split()[0].Length + 1)..];
                WeebsOut.Client.SendMessage(ChatMessage.Channel, $"{ApiRequests.GetSearch(search)}");
            }
            else
            {
                WeebsOut.Client.SendMessage(ChatMessage.Channel, $"Pls use the right format {HLE.Emojis.Emoji.PointRight} §wiki [wiki article name]");
            }
        }
    }
}
