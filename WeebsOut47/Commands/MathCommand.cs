using System;
using TwitchLib.Client.Models;

namespace WeebsOut47.Commands
{
    class MathCommand : Command
    {
        public MathCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }

        public override void SendMessage()
        {
            Console.WriteLine(" Rechne im Kopf :) ");
        }
    }
}
