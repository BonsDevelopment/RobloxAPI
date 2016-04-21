using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobloxAPI.Authentication;
using RobloxAPI.Exceptions;
using RobloxAPI.Extra_Functions;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RobloxAPI.RobloxAPI_Core
{
    class AccountDetails
    {
    
        public string GetRobux()
        {
            return GetValuesTemplate("d=\"nav-robux-amount\">","</span>");
        }

        public string GetTix()
        {
            return GetValuesTemplate("id=\"nav-tix-amount\">","</span>");
        }

        public string GetFriends()
        {
            return GetValuesTemplate("<h3>Friends (", ")</h3>");
        }

        public string RecentlyPlayedCount()
        {
            return Regex.Matches(Tokens.accountDetails, "list-item card game").Count.ToString();
        }

        public string[] RecentlyPlayedList()
        {
            
            string[] listOfGames = new string[3];
            
            string cutString = GetValuesTemplate("Recently Played", "Friend Activity");// made the string smaller for efficiency 

            for (int i = 0; i < 3; i++)
            {
                
                listOfGames[i] = SubString.subString(cutString, "title=\"", "\"", i);
                Regex remEx = new Regex(Regex.Escape("title=\""));
                cutString = remEx.Replace(cutString, "", 1);
                
            }
      
            return listOfGames;

        }

        public string[] GetFriendsNames()
        {
            
            int x = Regex.Matches(Tokens.accountDetails, "list-item friend").Count;
            
            string[] usernames = new string[x];
            if (usernames.Length == 0)
            {
                string[] noFriends = new string[1];
                noFriends[0] = "No Friends Found";
                return noFriends;
            }
            string cutString = GetValuesTemplate("hlist friend-list", "Recently Played");// made the string smaller for efficiency 

            for (int i = 0; i < x; i++)
			{
                usernames[i] = SubString.subString(cutString, "\"text-overflow friend-name\">", "</span>", i);
                Regex remEx = new Regex(Regex.Escape("\"text-overflow friend-name\">"));
                cutString = remEx.Replace(cutString, "", 1);
			}
            
            return usernames;
        }


        private string GetValuesTemplate(string start, string end)
        {
            try
            {
                if (Globals.signInState != States.loginState.SignedIn)
                    throw new InvalidRobloxAPIException("You aren't signed in. Login State - " + Globals.signInState);

                int Start = Tokens.accountDetails.IndexOf(start, 0) + start.Length;
                int End = Tokens.accountDetails.IndexOf(end, Start);
                return Tokens.accountDetails.Substring(Start, End - Start);
            }
            catch (Exception ex) { throw new UnableToLocateException(ex.ToString()); }
            
                
            
        }

     

        

    }
}
