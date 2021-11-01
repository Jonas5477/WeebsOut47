using TwitchLib.Client.Models;
using HLE.Time;

namespace WeebsOut47.Commands
{
    class UptimeCommand : Command
    {
        public UptimeCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }
        public override void SendMessage()
        {           
            WeebsOut.Client.SendMessage(ChatMessage.Channel, $"Der Bot ist nun seit {TimeHelper.ConvertUnixTimeToTimeStamp(Bot.Uptime())} online DansGame FBBlock AYAYA");
        }
    }
}
