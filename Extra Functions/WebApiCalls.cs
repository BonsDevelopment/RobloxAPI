using RobloxAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RobloxAPI.Extra_Functions
{
    class WebApiCalls
    {
        
       
        public string DownloadString(string url)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    string api = wc.DownloadString(url);
                    return api;
                }
                
            }
            catch (Exception ex) { throw new InvalidRobloxAPIException(ex.ToString()); }
            
        }
    }
}
