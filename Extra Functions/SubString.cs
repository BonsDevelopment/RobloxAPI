using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobloxAPI.Exceptions;

namespace RobloxAPI.Extra_Functions
{
    class SubString
    {
        public static string subString(string sentence, string start, string end, int count = 0 )
        {
            try
            {
                int Start = sentence.IndexOf(start, count) + start.Length;
                int End = sentence.IndexOf(end, Start);
                return sentence.Substring(Start, End - Start).Replace("\"", "");
            }
            catch (Exception ex) { throw new UnableToLocateException(ex.ToString()); }
        }
    }
}
