using System;
using System.Linq;
using System.Text.RegularExpressions;
using TwitchLib.Client.Models;
using WeebsOut47.Games;
using HLE.Emojis;

namespace WeebsOut47.Handler
{
    public class WhisperHandler
    {
        public WhisperHandler(Bot bot, string whisper)
        {
            WeebsOut = bot;
            string Hwhisper = whisper;
        }
        public Bot WeebsOut { get; }
        public string Hwhisper { get; }
        private static readonly Regex _message = new(@"^\w{4,}\s+[a-z]{4,12}$", RegexOptions.IgnoreCase | RegexOptions.Compiled, TimeSpan.FromMilliseconds(250));
        public void Handle()
        {
            Console.WriteLine("test1");
            if (_message.IsMatch(Hwhisper))
            {
                string[] wmessage = Hwhisper.ToLower().Split();
                string keyword = wmessage[1];
                string channel = wmessage[0];
                Console.WriteLine(channel);
                if (HangmanGame.HangManGames.Any(h => h.Channel == channel))
                {
                    Console.WriteLine("trest3");
                    HangmanGame.HangManGames.FirstOrDefault(h => h.Channel == channel).Keyword = keyword;
                    WeebsOut.Client.SendMessage(channel, string.Join((char)32, new string('_', keyword.Length)) + $" | Lives {Emoji.PointRight}{Emoji.Heart}{Emoji.Heart}{Emoji.Heart}{Emoji.Heart}{Emoji.Heart}{Emoji.Heart}{Emoji.Heart}{Emoji.Heart}{Emoji.Heart}{Emoji.Heart}");
                }
            }
        }
    }
}
