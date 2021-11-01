using System;
using TwitchLib.Client.Models;
using WeebsOut47.Commands;

namespace WeebsOut47.MessageCommands
{
    class BatChestCommand : Command
    {
        private static long _bat = 0;
        public BatChestCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }

        public override void SendMessage()
        {
            if (600000 < DateTimeOffset.Now.ToUnixTimeMilliseconds() - _bat)
            {
                if (ChatMessage.Username == "jann_amh_")
                {
                        Console.WriteLine("jann hat geschrieben");                 
                        WeebsOut.Client.SendMessage(ChatMessage.Channel, $"JannGa");
                        _bat = DateTimeOffset.Now.ToUnixTimeMilliseconds();                  
                }      
            }
        }
    }
}
