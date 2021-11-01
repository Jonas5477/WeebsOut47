using System.Collections.Generic;
using System.Linq;
using HLE.Emojis;
using HLE.Strings;
using TwitchLib.Client.Models;
using WeebsOut47.Utilities;

namespace WeebsOut47.Commands
{
    class ChatterCommand : Command
    {
        public ChatterCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }
        public override void SendMessage()
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
                List<string> chatter = ApiRequests.GetChatters(channel).Select(c=> c.Antiping()).ToList();
                WeebsOut.Client.SendMessage(ChatMessage.Channel, $"In dem chat von {channel} sind {chatter.Count} Chatter {Emoji.PointRight} {chatter.ToSequence()}");
            }
        }
    }
}
