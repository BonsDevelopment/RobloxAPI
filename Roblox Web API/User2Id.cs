using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobloxAPI.Extra_Functions;
using RobloxAPI.Exceptions;

namespace RobloxAPI.Roblox_Web_API
{
    class User2Id
    {
        public long UserToId(string user)
        {
            try
            {
                WebApiCalls w1 = new WebApiCalls();
                long x;
                string stringDownload = w1.DownloadString("http://api.roblox.com/users/get-by-username?username=" + user);
                string returnString = SubString.subString(stringDownload, "\"Id\":", ",\"U");
                if (Int64.TryParse(returnString, out x))
                    return x;
                else
                    throw new InvalidRobloxWebApiException("An error occured downloading from the web api, make sure the username is being used");
                
            }
            catch (Exception ex)
            {
                throw new InvalidRobloxWebApiException(ex.ToString());
            }
            
        }
    }
}
