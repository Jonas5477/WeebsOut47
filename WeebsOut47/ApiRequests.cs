using HLE.Collections;
using HLE.Strings;
using System.Collections.Generic;
using System.Text.Json;
using HLE.HttpRequests;
namespace WeebsOut47
{
    class ApiRequests
    {
        private const string _randomFox = "https://randomfox.ca/floof/";
        private const string _fact = "https://asli-fun-fact-api.herokuapp.com/";
        public static  string GetFunFact()
        {
            HttpGet request = new (_fact);
            if (request.ValidJsonData)
            {
                return request.Data.GetProperty("data").GetProperty("fact").GetString();
            }
            else
            {
                return request.Result;
            }
        }
        public static string GetRandomFox()
        {
            HttpGet request = new (_randomFox);
            if (request.ValidJsonData)
            {
                return request.Data.GetProperty("image").GetString();
            }
            else 
            {
                return request.Result;
            }
        }
        public static int GetChatterCount(string channel)
        {
            HttpGet request = new($"https://tmi.twitch.tv/group/user/{channel.Remove("#")}/chatters");
            return request.Data.GetProperty("chatter_count").GetInt32();
        }
        public static List<string> GetChatters(string channel)
        {
            HttpGet request = new($"https://tmi.twitch.tv/group/user/{channel.Remove("#")}/chatters");
            JsonElement chatters = request.Data.GetProperty("chatters");
            List<string> result = new();
            new string[]{ "broadcaster", "vips", "moderators", "staff", "admins", "global_mods", "viewers" }.ForEach(p =>
            {
                for (int i = 0; i < chatters.GetProperty(p).GetArrayLength(); i++)
                {
                    result.Add(chatters.GetProperty(p)[i].ToString());
                }
            });
            return result;
        }
        public static string GetWeather(string city)
        {
            HttpGet request = new($"https://goweather.herokuapp.com/weather/{city}");
            string temperature = request.Data.GetProperty("temperature").GetString();
            string wind = request.Data.GetProperty("wind").GetString();
            string description = request.Data.GetProperty("description").GetString();
            if (request.ValidJsonData)
            {
                return $"In {city} the temparute is {temperature}. The wind velocity is {wind} and the weather is {description}";
            }
            else
            {
                return request.Result;
            }
            

        }
    }
}
