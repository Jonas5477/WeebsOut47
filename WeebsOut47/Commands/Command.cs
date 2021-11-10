using TwitchLib.Client.Models;

namespace WeebsOut47.Commands
{
    public abstract class Command 
    {
        public Bot WeebsOut { get; }
        public ChatMessage ChatMessage { get; }
        public string message { get; }
        public Command(Bot weebsout, ChatMessage chatMessage)
        {
            WeebsOut = weebsout;
            ChatMessage = chatMessage;
            
        }
        public abstract void SendMessage();
    }
}