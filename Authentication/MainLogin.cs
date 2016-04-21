using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RobloxAPI.Exceptions;
using RobloxAPI.States;
using RobloxAPI.RobloxAPI_Core;

namespace RobloxAPI.Authentication
{
     class MainLogin
    {
        
        public MainLogin(string user,string pass)
        {
            Globals.signInState = loginState.Processing;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.roblox.com/NewLogin");
            string postData = String.Format("username={0}&password={1}&submitLogin=Log+In&ReturnUrl=", user, pass);
            byte[] data = Encoding.UTF8.GetBytes(postData);
            request.Method = "POST";
            request.AllowAutoRedirect = false;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            Tokens.reqCookie = RetrieveCookie(request);
            Globals.signInState = loginState.SignedIn;
         
        }


        private string RetrieveCookie(HttpWebRequest htr)
        {
            using (var response = (HttpWebResponse)htr.GetResponse())
            {

                foreach (string item in response.Headers.Keys)
                {
                    try
                    {
                        if (item == "Set-Cookie")
                        {

                            int Start = response.Headers[item].IndexOf(".ROBLOSECURITY=_", 0);
                            int End = response.Headers[item].IndexOf("; domain=", Start);
                            return response.Headers[item].Substring(Start, End - Start);

                        }
                    }
                    catch
                    {
                        Globals.signInState = loginState.Error;
                        throw new InvalidRobloxAPIException("Couldn't retrieve the Cookie, make sure you're using the correct login credentials.");
                        
                    }
                }
                return null;
            }
        }
    }
}
