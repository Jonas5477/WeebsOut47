using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client.Models;

namespace WeebsOut47.Commands
{
    class HelpCommand : Command
    {
        public HelpCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }
        public override void SendMessage()
        {
            WeebsOut.Client.SendMessage(ChatMessage.Channel, $"All posible commands 👉 github.com/Jonas5477/WeebsOut47/blob/master/README.md");
        }
    }
}
