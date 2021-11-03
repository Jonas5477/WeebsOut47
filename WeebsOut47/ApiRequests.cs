using HLE.Collections;
using HLE.HttpRequests;
using HLE.Strings;
using System.Collections.Generic;
using System.Text.Json;
using System.Web;


namespace WeebsOut47
{
    class ApiRequests
    {
        private const string _randomFox = "https://randomfox.ca/floof/";
        private const string _bored = "https://www.boredapi.com/api/activity/";
        private const string _joke = "https://v2.jokeapi.dev/joke/Any?blacklistFlags=racist,sexist";
        public static string GetJoke()
        {
            HttpGet request = new HttpGet(_joke);
            string type = request.Data.GetProperty("type").GetString();
            if (request.ValidJsonData)
            {
                if (type == "twopart")
                {
                    return $"{request.Data.GetProperty("setup").GetString()} PauseChamp {request.Data.GetProperty("delivery").GetString()} haHAA";
                }
                else
                {
                    return $"{request.Data.GetProperty("joke").GetString()} haHAA";
                }
            }
            else
            {
                return request.Result;
            }
        }
        public static string GetBored()
        {
            HttpGet request = new(_bored);
            string activity = request.Data.GetProperty("activity").GetString();
            if (request.ValidJsonData)
            {
                return $"{activity} monkaUOMEGA";
            }
            else
            {
                return request.Result;
            }
        }
        public static string GetRandomFox()
        {
            HttpGet request = new(_randomFox);
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
            new string[] { "broadcaster", "vips", "moderators", "staff", "admins", "global_mods", "viewers" }.ForEach(p =>
             {
                 for (int i = 0; i < chatters.GetProperty(p).GetArrayLength(); i++)
                 {
                     result.Add(chatters.GetProperty(p)[i].ToString());
                 }
             });
            return result;
        }
        public static string GetMath(string rechnung)
        {
            rechnung = HttpUtility.UrlEncode(rechnung);
            HttpGet request = new($"http://api.mathjs.org/v4/?expr={rechnung}");
            return request.Result;
        }
        public static string GetSearch(string search)
        {
            search = HttpUtility.UrlEncode(search);
            HttpGet request = new($"https://de.wikipedia.org/w/rest.php/v1/page/{search}");
            bool Okayge = request.Data.TryGetProperty("httpCode", out JsonElement httpCode);
            if (Okayge == true)
            {
                return $" Unlucky this page doesnt exist :( ";
            }
            else
            {
                string source = request.Data.GetProperty("source").GetString();
                if (request.ValidJsonData)
                {
                    if (source.Length > 499)
                    {
                        string shortsource = source.Substring(0, 499);
                        return $"{shortsource}";
                    }
                    else
                    {
                        return $"{source}";
                    }
                }
                else
                {
                    return request.Result;
                }
            }
        }
        public static string GetWeather(string city)
        {
            HttpGet request = new($"https://goweather.herokuapp.com/weather/{city}");
            string temperature = request.Data.GetProperty("temperature").GetString();
            string wind = request.Data.GetProperty("wind").GetString();
            string description = request.Data.GetProperty("description").GetString();
            if (string.IsNullOrEmpty(temperature))
            {
                return $"You have to enter a valid cityname!";
            }
            else
            {
                if (request.ValidJsonData)
                {
                    return $"In {city.ToUpper()[0] + city.Substring(1)} the temperature is {temperature}. The wind velocity is {wind} and the weather is {description}";
                }
                else
                {
                    return request.Result;
                }

            }
        }
    }
}
