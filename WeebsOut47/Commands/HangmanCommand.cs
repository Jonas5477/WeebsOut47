using HLE.Emojis;
using TwitchLib.Client.Models;
using WeebsOut47.Games;

namespace WeebsOut47.Commands
{
    class HangmanCommand : Command
    {
        public HangmanCommand(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }
        public override void SendMessage()
        {
            HangmanGame.HangManGames.Add(new(ChatMessage.Channel ,ChatMessage.Username));
            WeebsOut.Client.SendMessage(ChatMessage.Channel, $"Pls whisper me your Keyword in this format {Emoji.PointRight} [Channel] [Keyword]");           
        }
    }
}
