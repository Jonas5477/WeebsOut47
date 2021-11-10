using HLE.Strings;
using System.Collections.Generic;

namespace WeebsOut47.Utilities
{
    public static class MessageHelper
    {
        public static string Prepare(this string input)
        {
            return input.Remove("󠀀").TrimAll();
        }
    }
}
