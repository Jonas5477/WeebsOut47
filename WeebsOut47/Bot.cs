using HLE.Strings;
using System;
using System.Linq;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;
using WeebsOut47.Handler;

namespace WeebsOut47
{
    public class Bot
    {
        public TwitchClient Client { get; private set; }
        public static long Timer { get; set; } = 0;
        public Bot()
        {
            Timer = DateTimeOffset.Now.ToUnixTimeMilliseconds();           
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
            Client.OnMessageSent += Client_OnMessageSent;
            Client.OnConnectionError += Client_OnConnectionError;
            Client.OnDisconnected += Client_OnDisconnected;
            Client.OnWhisperReceived += Client_OnWhisperReceived;
            Client.OnError += Client_OnError;
            Client.OnLog += Client_OnLog;
            Client.Connect();
        }

        private void Client_OnLog(object sender, OnLogArgs e)
        {
           
        }
        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            new MessageHandler(this, e.ChatMessage).Handle();
            Console.WriteLine($"{e.ChatMessage.Channel}-> {e.ChatMessage.DisplayName}: {e.ChatMessage.Message}");
        }
        private void Client_OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
            string whisper = e.WhisperMessage.Message.Remove("󠀀").TrimAll();
            Console.WriteLine($"[WHISPER] --> {e.WhisperMessage.Username}: {whisper}");
            new WhisperHandler(this, whisper).Handle();
        }
        private void Client_OnError(object sender, TwitchLib.Communication.Events.OnErrorEventArgs e)
        {
            Console.WriteLine($"Error detected");
        }
        private void Client_OnDisconnected(object sender, TwitchLib.Communication.Events.OnDisconnectedEventArgs e)
        {
            Console.WriteLine("Bot disconnected");
        }
        private void Client_OnConnectionError(object sender, OnConnectionErrorArgs e)
        {
            Console.WriteLine("ConnectionError detected");
        }
        private void Client_OnMessageSent(object sender, OnMessageSentArgs e)
        {
            Console.WriteLine($"{e.SentMessage.Channel}-> {e.SentMessage.DisplayName}: {e.SentMessage.Message}");
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
        public static long Uptime()
        {
            return Timer;
        }
    }
}

