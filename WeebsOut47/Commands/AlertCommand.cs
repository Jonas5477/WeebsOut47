using System;
using System.Collections.Generic;
using HLE.Emojis;
using TwitchLib.Client.Models;

namespace WeebsOut47.Commands
{
    public class AlertCommand : Command
    {
        public AlertCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }

        // Random randNum = new Random();
        //int randPos = randnu
        public override void SendMessage()
        {
            string[] text = { $"/me WeebsOut { Emoji.RotatingLight}RAUS JETZT!", $"/me pajaSWA { Emoji.RotatingLight}WEEBS EVERYWHERE!", $"/me Weirdga {Emoji.RotatingLight} WEEBS OUT!", $"/me {Emoji.Bear}{Emoji.Telescope} pajaR OH NO", $"/me pajaMAD {Emoji.RotatingLight} JUST LEAVE!"};
            string[] text2 = { $"FEELSDOEnkman {Emoji.RotatingLight}", $"pepoDank { Emoji.RotatingLight }" };
            Random randNum = new Random();
            int randPos = randNum.Next(text.Length);
            int randPos2 = randNum.Next(text2.Length);
            WeebsOut.Client.SendMessage(ChatMessage.Channel, text[randPos]);
            WeebsOut.Client.SendMessage(Accountinfo.SecretOfflinechat,text2[randPos2]);
        }
    }
}
