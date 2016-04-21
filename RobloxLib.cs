using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobloxAPI.Authentication;
using RobloxAPI.RobloxAPI_Core;
using RobloxAPI.Roblox_Web_API;
using RobloxAPI.Exceptions;
using RobloxAPI.Extra_Functions;
using System.IO;

namespace RobloxAPI
{
    public class RobloxLib
    {

        AccountDetails accountD = new AccountDetails();
        User2Id uid = new User2Id();
        IdtoUsername id2user = new IdtoUsername();
        UsernameTaken userTaken  = new UsernameTaken();
        AssetID aID = new AssetID();

        public void Login(string user, string pass)
        {
            MainLogin m1 = new MainLogin(user,pass);
            GrabDetails g1 = new GrabDetails();
        }

     

       // public string GetTix() { return accountD.GetTix(); } // removed by Roblox, doesn't work anymore.

        public string GetRobux() { return accountD.GetRobux(); }

        public string GetFriendCount() { return accountD.GetFriends(); }

        public string[] GetFriendsList() { return accountD.GetFriendsNames(); }

        public string[] RecentlyPlayedList() { return accountD.RecentlyPlayedList(); }
        
        public string RecentlyPlayedCount() { return accountD.RecentlyPlayedCount(); }

        public long GetUserID(string user) { return uid.UserToId(user); }

        public string GetUsername(string id) { return id2user.IDUser(id); }


        public string UsernameAvailable(string user)
        {
           
            if (userTaken.UsernameExists(user))
                return "Available";
            else
                return "Unavailable";
        }


        public void DownloadAssetID(int id,string saveLoc)
        {
            foreach (var item in aID.GetAssets(id))
            {
                AssetDownloader.DownloadAssetID(item,saveLoc);
            } 
        }

        
    }
}
