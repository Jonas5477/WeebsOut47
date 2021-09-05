using HLE.Collections;
using HLE.Strings;
using System.Collections.Generic;
using System.Text.Json;
namespace WeebsOut47
{
    class ApiRequests
    {
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
    }
}
