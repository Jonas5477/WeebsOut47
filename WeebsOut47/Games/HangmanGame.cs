using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace WeebsOut47.Games
{
    public class HangmanGame
    {
        public static List<HangmanGame> HangManGames { get; } = new();
        public string Channel { get; }
        public string User { get; }
        public string Keyword { get; set; }
        public int Lives { get; private set; }
        private const byte _maxhealth = 10;
        public HangmanGame(string channel, string user)
        {
            Channel = channel;
            User = user;
        }      
        //public string GetHearts()
        //{
        //    String[] Hearts = new string[_maxhealth];
        //}
    }
}
