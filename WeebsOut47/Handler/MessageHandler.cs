﻿using System.Linq;
using TwitchLib.Client.Models;
using WeebsOut47.Commands;
using WeebsOut47.MessageCommands;

namespace WeebsOut47.Handler
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
            if (ChatMessage.Message.StartsWith("§"))
            {
                new CommandHandler(WeebsOut, ChatMessage).SendMessage();
            }
            else if (ChatMessage.Message.ToLower().Contains("ayaya"))
            {
                new AyayaCommand(WeebsOut, ChatMessage).SendMessage();
            }
            else if (ChatMessage.Message.ToLower().Contains("batchest") || ChatMessage.Message.ToLower().Contains("hendrikchest"))
            {
                new BatChestCommand(WeebsOut, ChatMessage).SendMessage();
            }
        }
    }
}
