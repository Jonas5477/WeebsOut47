using HLE.Emojis;
using HLE.Strings;
using System.Collections.Generic;
using TwitchLib.Client.Models;

namespace WeebsOut47.Commands
{
    class CommandHandler : Command
    {
        public CommandHandler(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
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
                List<string> chatter = ApiRequests.GetChatters(channel);
                WeebsOut.Client.SendMessage(ChatMessage.Channel, $"In dem chat von {channel} sind {chatter.Count} Chatter {Emoji.PointRight} {chatter.ToSequence()}");
            }
            else if (message.StartsWith("github"))
            {
                new GithubCommand(WeebsOut, ChatMessage).SendMessage();
            }
            else if (message.StartsWith("help"))
            {
                new HelpCommand(WeebsOut, ChatMessage).SendMessage();
            }
            else if (message.StartsWith("ping"))
            {
                new PingCommand(WeebsOut, ChatMessage).SendMessage();
            }
            else if (message.StartsWith("uptime"))
            {
                new UptimeCommand(WeebsOut, ChatMessage).SendMessage();
            }
            else if (message.StartsWith("color"))
            {
                new ColorCommand(WeebsOut, ChatMessage).SendMessage();
            }
            else if (message.StartsWith("id"))
            {
                new IdCommand(WeebsOut, ChatMessage).SendMessage();
            }
            else if (message.StartsWith("sub"))
            {
                new SubCommand(WeebsOut, ChatMessage).SendMessage();
            }
        }
    }
}
