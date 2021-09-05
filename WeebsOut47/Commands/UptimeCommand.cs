using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client.Models;

namespace WeebsOut47.Commands
{
    class UptimeCommand : Command
    {
        public UptimeCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }

        public override void SendMessage()
        {
            Bot.Uptime(DateTimeOffset.Now.ToUnixTimeMilliseconds(), Bot._timer);
        }
    }
}
