using System.Collections.Generic;
using System.Linq;
using TwitchLib.Client.Models;
using WeebsOut47.Commands;
using WeebsOut47.MessageCommands;

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
        Dictionary<long, string> openWith = new();
        public void Handle()
        {
            if (ChatMessage.Message.StartsWith("§"))
            {
                new CommandHandler(WeebsOut, ChatMessage).SendMessage();
            }
            else if (ChatMessage.Message.ToLower().Contains("ayaya"))
            {
                new AyayaCommand(WeebsOut, ChatMessage).SendMessage(); 
            }
            else if (Accountinfo.Weebs.Split().ToList().Contains(ChatMessage.Username))
            {
                new WeLostCommand(WeebsOut, ChatMessage).SendMessage();
            }
            else if (ChatMessage.Message.ToLower().Contains("batchest"))
            {
                new BatChestCommand(WeebsOut, ChatMessage).SendMessage();
            }
        }
    }
}

