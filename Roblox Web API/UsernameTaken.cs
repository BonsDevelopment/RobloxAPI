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
    class UsernameTaken
    {
        public bool UsernameExists(string username)
        {

            WebApiCalls w1 = new WebApiCalls();
            string api = w1.DownloadString("http://www.roblox.com/UserCheck/DoesUsernameExist?username=" + username);
            if (api.Contains("true"))
                return false;
            else
                return true;
        }
    }

  
}
