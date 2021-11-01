using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WeebsOut47.Utilities
{
    public static class Stringhelper
    {
        public static string Antiping(this string value) { 
        
            return value.Insert(value.Length / 2, "󠀀");
        }
    }
}
