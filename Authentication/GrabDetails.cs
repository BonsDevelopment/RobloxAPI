using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobloxAPI.States;
using System.Net;
using System.IO;
using RobloxAPI.RobloxAPI_Core;
using RobloxAPI.Exceptions;

namespace RobloxAPI.Authentication
{
    class GrabDetails
    {
       
        public GrabDetails()
        {
            if (Globals.signInState == loginState.SignedIn) {
                using (WebClient wb = new WebClient())
                {
                   
                    wb.Proxy = null; 
                    wb.Headers.Add(HttpRequestHeader.Cookie, Tokens.reqCookie);
                    Tokens.accountDetails = wb.DownloadString("http://www.roblox.com/home");
                }

            }
            else
            {
                throw new InvalidRobloxAPIException("You aren't signed in. Login State - " + Globals.signInState);
            }
            
            
        }
    }
}
