using TwitchLib.Client.Models;

namespace WeebsOut47.Utilities
{
    public static class TwitchHelper
    {
        public static string GetMessage(this ChatMessage chatMessage)
        {
            return chatMessage.Message.Prepare();
        }
    }
}
