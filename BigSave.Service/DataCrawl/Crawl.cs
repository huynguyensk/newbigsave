using System.Net;
using BigSave.Core.Flyer;
using Newtonsoft.Json;

namespace BigSave.Service.DataCrawl
{
    public static class Crawl
    {
        public static CrawlObject GetData(string url)
        {
            using (var webClient = new WebClient())
            {
                var json = string.Empty; // attempt to download JSON data as a string 
                webClient.Headers.Add("Accept", "application/json");
                json = webClient.DownloadString(url);
                var crawlObjects = JsonConvert.DeserializeObject<CrawlObject>(json);
                return crawlObjects;
            }
        }
    }
}