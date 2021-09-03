using System;
using System.Linq;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;
using WeebsOut47.Twitch.Messages;


namespace WeebsOut47
{
    public class Bot
    {
        public TwitchClient Client { get; private set; }
        public static long _timer { get; set; } = 0;


        public Bot()
        {
            _timer = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            

            ConnectionCredentials credentials = new(Accountinfo.Name, Accountinfo.Token);
            ClientOptions clientOptions = new()
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(2)
            };


            WebSocketClient customClient = new(clientOptions);
            Client = new TwitchClient(customClient);
            Client.Initialize(credentials, Accountinfo.Channel.Split().ToList());

            Client.OnConnected += Client_OnConnected;
            Client.OnJoinedChannel += Client_OnJoinedChannel;
            Client.OnMessageReceived += Client_OnMessageReceived;

            Client.Connect();
        }
        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            new MessageHandler(this, e.ChatMessage).Handle();
            Console.WriteLine($"{e.ChatMessage.Channel}-> {e.ChatMessage.Username}: {e.ChatMessage.Message}");
        }
        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            Console.WriteLine($"Connected to {e.Channel}");
            Client.SendMessage(e.Channel, "");
        }
        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine("Connected");
        }
        public static long Uptime(double Reboot, double now)
        {
            double Ergebnis = Reboot - now;
            return (long)Ergebnis;
            
            //double tage = Ergebnis / 8.64e+7;
            //Ergebnis = (long)(Ergebnis % 8.64e+7);
            //double stunden = Ergebnis / 3.6e6;
            //Ergebnis = (long)(Ergebnis % 3.6e6);
            //double minuten = Ergebnis / 60000;
            //Ergebnis = (long)(Ergebnis % 60000);
            //double sekunden = Ergebnis / 1000;
            //Ergebnis = (long)(Ergebnis % 1000);

            //Console.WriteLine($"WeebsOut47 ist jetzt seit {tage}d {stunden}h {minuten}min und {sekunden}sek online Okayge");          
        }
    }
}

