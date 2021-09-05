using HLE.Emojis;
using HLE.Strings;
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
        private static long _ayaya = 0;
        private static long _user = 0;
        private static long _mods = 0;
        private static long _bat = 0;
        Dictionary<long, string> openWith = new();

        public void Handle()

        {
            if (ChatMessage.Message.StartsWith("§"))
            {
                string message = ChatMessage.Message[1..].ToLower();
                if (message.StartsWith("chatter"))
                {
                    string channel;
                    if (ChatMessage.Message.Split().Length > 1)
                    {
                        channel = message.Split()[1];
                    }
                    else
                    {
                        channel = ChatMessage.Channel;
                    }
                    List<string> chatter = ApiRequests.GetChatters(channel);
                    WeebsOut.Client.SendMessage(ChatMessage.Channel, $"In dem chat von {channel} sind {chatter.Count} Chatter {Emoji.PointRight} {chatter.ToSequence()}");
                }
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
                if (message.StartsWith("uptime"))
                {
                    Bot.Uptime(DateTimeOffset.Now.ToUnixTimeMilliseconds(), Bot._timer);
                }
                if (message.StartsWith("color"))
                {
                    WeebsOut.Client.SendMessage(ChatMessage.Channel, $"Your {ChatMessage.Color} has the Hex Code {ChatMessage.ColorHex}");
                }
                if (message.StartsWith("id"))
                {
                    WeebsOut.Client.SendMessage(ChatMessage.Channel, $"Your ID is {ChatMessage.UserId} and the ID of this Chat Room is {ChatMessage.RoomId} FeelsOkayMan");
                }
                if (message.StartsWith("test"))
                {
                    WeebsOut.Client.SendMessage(ChatMessage.Channel, $"{ChatMessage.TmiSentTs}");
                }
                if (message.StartsWith("sub"))
                {
                    if (ChatMessage.IsSubscriber)
                    {
                        WeebsOut.Client.SendMessage(ChatMessage.Channel, $"{ChatMessage.Username} is currently subscribing and has subcribed for {ChatMessage.SubscribedMonthCount} Months FeelsGoodMan");
                    }
                    else
                    {
                        WeebsOut.Client.SendMessage(ChatMessage.Channel, $"DansGame {ChatMessage.Username} isn't subscribing at the moment DansGame total months subscribed: {ChatMessage.SubscribedMonthCount} FeelsWeirdMan");
                    }
                }
                if (ChatMessage.IsModerator)
                {
                    if (600000 < DateTimeOffset.Now.ToUnixTimeMilliseconds() - _mods)
                    {
                        WeebsOut.Client.SendMessage(ChatMessage.Channel, " M OMEGALUL DS");
                        _mods = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    }
                }
            }
            if (ChatMessage.Message.ToLower().Contains("ayaya"))
            {
                if (600000 < DateTimeOffset.Now.ToUnixTimeMilliseconds() - _ayaya)
                {
                    if (ChatMessage.IsModerator)
                    {
                        WeebsOut.Client.SendMessage(ChatMessage.Channel, "WEEBS OUT DansGame");
                    }
                    else
                    {
                        WeebsOut.Client.SendMessage(ChatMessage.Channel, $"/timeout {ChatMessage.Username} 10s");
                    }
                    _ayaya = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                }
            }
            if (Accountinfo.Weebs.Split().ToList().Contains(ChatMessage.Username))
            {
                if (60000000 < DateTimeOffset.Now.ToUnixTimeMilliseconds() - _user)
                {
                    WeebsOut.Client.SendMessage(ChatMessage.Channel, $"We lost {ChatMessage.Username} PepeHands");
                    _user = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                }
            }
            if (ChatMessage.Message.ToLower().Contains("batchest"))
            {
                if (60000000 < DateTimeOffset.Now.ToUnixTimeMilliseconds() - _bat)
                {
                    if (ChatMessage.Username == "jann_amh_")
                    {
                        WeebsOut.Client.SendMessage(ChatMessage.Channel, $"JannGa");
                        _bat = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    }
                }
            }
        }
    }
}

