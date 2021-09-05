using TwitchLib.Client.Models;

namespace WeebsOut47
{
    public abstract class Command 
    {
        public Bot WeebsOut { get; }

        public ChatMessage ChatMessage { get; }
        public Command(Bot weebsout, ChatMessage chatMessage)
        {
            WeebsOut = weebsout;
            ChatMessage = chatMessage;
        }

        public abstract void SendMessage();
    }
}