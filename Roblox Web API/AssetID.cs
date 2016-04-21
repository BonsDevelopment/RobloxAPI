using RobloxAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RobloxAPI.Extra_Functions;

namespace RobloxAPI.Roblox_Web_API
{
    class AssetID
    {
        public string[] GetAssets(int ID)
        {
            WebApiCalls w1 = new WebApiCalls();
            string dStrings = w1.DownloadString("http://www.roblox.com/Asset/AvatarAccoutrements.ashx?userId=" + ID.ToString());
            string[] splitStrings = dStrings.Split(';');
            return splitStrings;
        }
    }
}
