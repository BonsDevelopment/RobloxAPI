using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RobloxAPI.Extra_Functions
{
    class AssetDownloader
    {
        public static void DownloadAssetID(string rAsset, string saveLocation)
        {
            // doesn't fucking work, Roblox likes to fuck me harder than aer1ths mother
            // will download files, just empty files.
            string fileName = "";
            for (int i = 0; i < rAsset.Length; i++)
            {
                if (Char.IsNumber(rAsset[i]))
                    fileName += rAsset[i]; 
            }
            if (rAsset.Contains("BodyColors.ashx"))
                fileName = "BodyColors.ashx.xml";
            
            WebClient webClient = new WebClient();
            webClient.Headers.Set("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:45.0) Gecko/20100101 Firefox/45.0");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadFileAsync(new Uri(rAsset), saveLocation + "\\" + fileName);
        }

        public static void Completed(object sender, AsyncCompletedEventArgs e)
        {
            
        }
    }
}
