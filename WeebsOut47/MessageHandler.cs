using System.Linq;
using TwitchLib.Client.Models;

namespace WeebsOut47.Twitch.Messages
{
    public class MessageHandler
    {
        public ChatMessage ChatMessage { get; }
        public Bot WeebsOut { get; }

        public MessageHandler(Bot bot, ChatMessage chatMessage)
        {
            ChatMessage = chatMessage;
            WeebsOut = bot;
        }

        public void Handle()
        {
            {

                if (ChatMessage.Message.StartsWith("§"))
                {
                    if (ChatMessage.Message.Contains("ping"))
                    {
                        WeebsOut.Client.SendMessage(ChatMessage.Channel, "pong");
                    }
                    if (ChatMessage.Message.Contains("color"))
                    {
                        WeebsOut.Client.SendMessage(ChatMessage.Channel, $"Your {ChatMessage.Color} has the Hex Code {ChatMessage.ColorHex}");
                    }
                    if (ChatMessage.IsModerator)
                    {
                        WeebsOut.Client.SendMessage(ChatMessage.Channel, " M OMEGALUL DS");
                    }

                }
                if (ChatMessage.Message.Contains("ayaya"))
                {
                    if (ChatMessage.IsModerator)
                    {
                        WeebsOut.Client.SendMessage(ChatMessage.Channel, "WEEBS OUT DansGame");
                    }
                    else
                    {
                        WeebsOut.Client.SendMessage(ChatMessage.Channel, $"/timeout {ChatMessage.Username} 10s");
                    }
                }
                if (ChatMessage.Username.Contains($"[{Accountinfo.Weebs.Split().ToList()}"))
                {
                    WeebsOut.Client.SendMessage(ChatMessage.Channel, $"We lost {ChatMessage.Username} PepeHands");
                }

            }
        }
    }
}
