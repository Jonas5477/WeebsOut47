using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client.Models;

namespace WeebsOut47
{
    class GithubCommand : Command
    {
        public GithubCommand(Bot weebsout, ChatMessage chatmessage):base(weebsout,chatmessage)
        {
            
        }
        public override void SendMessage()
        {
            WeebsOut.Client.SendMessage(ChatMessage.Channel, "Repository of WeebsOut47 github.com/Jonas5477/WeebsOut47");
        }
    }
}
