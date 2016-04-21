using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RobloxAPI.Exceptions;
using RobloxAPI.Extra_Functions;

namespace RobloxAPI.Roblox_Web_API
{
     class IdtoUsername
    {
        public string IDUser(string ID)
        {
            try
            {
                
                WebApiCalls w1 = new WebApiCalls();
                string api = w1.DownloadString("http://api.roblox.com/Users/" + ID);
                return SubString.subString(api, "\"Username\":", ",");
                
            }
            catch (Exception ex) { throw new InvalidRobloxAPIException(ex.ToString()); }
        }
    }
}
