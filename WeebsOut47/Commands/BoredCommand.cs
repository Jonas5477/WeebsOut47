﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client.Models;

namespace WeebsOut47.Commands
{
    class BoredCommand : Command
    {
        public BoredCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }

        public override void SendMessage()
        {
            WeebsOut.Client.SendMessage(ChatMessage.Channel, $"{ApiRequests.GetBored()}") ;
        }
    }
}
