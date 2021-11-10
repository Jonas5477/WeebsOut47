
namespace WeebsOut47.Utilities
{
    public static class Stringhelper
    {
        public static string Antiping(this string value) { 
        
            return value.Insert(value.Length / 2, "󠀀");
        }
    }
}
