using TwitchLib.Client.Models;
using WeebsOut47.Commands;

namespace WeebsOut47.Handler
{
    class CommandHandler : Command
    {
        public CommandHandler(Bot weebsout, ChatMessage chatMessage) : base(weebsout, chatMessage)
        {
        }
        public override void SendMessage()
        {
            string message = ChatMessage.Message[1..].ToLower();
            if (message.StartsWith("chatter"))
            {
                new ChatterCommand(WeebsOut, ChatMessage).SendMessage();
            }
            else if (message.StartsWith("math"))
            {
                new MathCommand(WeebsOut, ChatMessage).SendMessage();
            }
            else if (message.StartsWith("github"))
            {
                new GithubCommand(WeebsOut, ChatMessage).SendMessage();
            }
            else if (message.StartsWith("help"))
            {
                new HelpCommand(WeebsOut, ChatMessage).SendMessage();
            }
            else if (message.StartsWith("ping"))
            {
                new PingCommand(WeebsOut, ChatMessage).SendMessage();
            }
            else if (message.StartsWith("uptime"))
            {
                new UptimeCommand(WeebsOut, ChatMessage).SendMessage();
            }
            else if (message.StartsWith("color"))
            {
                new ColorCommand(WeebsOut, ChatMessage).SendMessage();
            }
            else if (message.StartsWith("id"))
            {
                new IdCommand(WeebsOut, ChatMessage).SendMessage();
            }
            else if (message.StartsWith("sub"))
            {
                new SubCommand(WeebsOut, ChatMessage).SendMessage();
            }
            else if (message.StartsWith("hangman"))
            {
                new HangmanCommand(WeebsOut, ChatMessage).SendMessage();
            }
            else if (message.StartsWith("fox"))
            {
                new RandomPictureCommand(WeebsOut, ChatMessage).SendMessage();
            }
            else if (message.StartsWith("bored"))
            {
                new BoredCommand(WeebsOut, ChatMessage).SendMessage();
            }
            else if (message.StartsWith("weather"))
            {
                new WeatherCommand(WeebsOut, ChatMessage).SendMessage();
            }
            else if (message.StartsWith("joke"))
            {
                new JokeCommand(WeebsOut, ChatMessage).SendMessage();
            }
            else if (message.StartsWith("wiki"))
            {
                new WikiCommand(WeebsOut, ChatMessage).SendMessage();
            }
        }
    }
}
