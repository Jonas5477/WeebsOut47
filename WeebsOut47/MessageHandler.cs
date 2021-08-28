using System;
using System.Collections.Generic;
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

        private static long _timeStamp = 0;
        private static string _user;
        Dictionary<long, string> openWith = new();

        public void Handle()

        {
            if (ChatMessage.Message.StartsWith("§"))
            {
                string message = ChatMessage.Message[1..].ToLower();
                if (message.StartsWith("github"))
                {
                    WeebsOut.Client.SendMessage(ChatMessage.Channel, "Repository of WeebsOut47 github.com/Jonas5477/WeebsOut47");
                }
                if (message.StartsWith("help"))
                {
                    WeebsOut.Client.SendMessage(ChatMessage.Channel, $"All posible commands 👉 github.com/Jonas5477/WeebsOut47/blob/master/README.md");
                }
                if (message.StartsWith("ping"))
                {
                    WeebsOut.Client.SendMessage(ChatMessage.Channel, "pong ");
                }
                if (message.StartsWith("color"))
                {
                    WeebsOut.Client.SendMessage(ChatMessage.Channel, $"Your {ChatMessage.Color} has the Hex Code {ChatMessage.ColorHex}");
                }
                if (ChatMessage.IsModerator)
                {
                    if (600000 < DateTimeOffset.Now.ToUnixTimeMilliseconds() - _timeStamp)
                    {
                        WeebsOut.Client.SendMessage(ChatMessage.Channel, " M OMEGALUL DS");
                    }
                }
            }
            if (ChatMessage.Message.ToLower().Contains("ayaya"))
            {
                if (600000 < DateTimeOffset.Now.ToUnixTimeMilliseconds() - _timeStamp)
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
            }
            if (Accountinfo.Weebs.Split().ToList().Contains(ChatMessage.Username))
            {
                if (60000000 < DateTimeOffset.Now.ToUnixTimeMilliseconds() - _timeStamp)
                {
                    WeebsOut.Client.SendMessage(ChatMessage.Channel, $"We lost {ChatMessage.Username} PepeHands");
                    _timeStamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                }
            }
        }
    }
}
