using HLE.Emojis;
using System;
using TwitchLib.Client.Models;

namespace WeebsOut47.Commands
{
    public class AlertCommand : Command
    {
        public static bool Jebaited { get; set; } = false;
        private static readonly string[] _text = { $"/me WeebsOut { Emoji.RotatingLight} RAUS JETZT!", $"/me pajaSWA {Emoji.RotatingLight} WEEBS EVERYWHERE!", $"/me Weirdga {Emoji.RotatingLight} WEEBS OUT!", $"/me {Emoji.Bear}{Emoji.Telescope} pajaR OH NO", $"/me pajaMAD {Emoji.RotatingLight} JUST LEAVE!" };
        private static readonly string[] _text2 = { $"FEELSDOEnkman {Emoji.RotatingLight}", $"pepoDank {Emoji.RotatingLight}", $"JannGa {Emoji.RotatingLight}" };
        public static bool Waiting { get; set; } = false;
        public AlertCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }
        public override void SendMessage()
        {
            if (ChatMessage.Message.Equals($"pajaS {Emoji.RotatingLight} ALERT"))
            {
                if (!Jebaited)
                {
                    Random randNum = new();
                    int randPos = randNum.Next(_text.Length);
                    int randPos2 = randNum.Next(_text2.Length);
                    Waiting = true;
                    WeebsOut.Client.SendMessage(ChatMessage.Channel, _text[randPos]);
                    WeebsOut.Client.SendMessage(Accountinfo.SecretOfflinechat, _text2[randPos2]);
                }
                else
                {
                    WeebsOut.Client.SendMessage(ChatMessage.Channel, $"Nice Jebasted");
                    Jebaited = false;
                }
            }
            else
            {
                Jebaited = false;
            }

        }
        public void SendIrgendneFolgeNachricht()
        {
            if (Waiting)
            {
                if (ChatMessage.Username == "okayegteatime" || ChatMessage.Username == "apudoingstuff" || ChatMessage.Username == "habibiteatime")
                {
                    WeebsOut.Client.SendMessage(Accountinfo.SecretOfflinechat, $"forsenLaughingAtYou {ChatMessage.Username} So slow");
                }
                Waiting = false;
            }
        }
    }
}
