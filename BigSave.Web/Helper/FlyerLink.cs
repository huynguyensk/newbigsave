using System.Collections.Generic;
using HtmlAgilityPack;

namespace BigSave.Web.Helper
{
    public class FlyerLink
    {
        public static List<string> GetLink(string flyerCategory)
        {
            var result = new List<string>();
            var url = "https://www.flyertown.ca/d/p/flyertown?locale=en&p=flyertown&stack=" + flyerCategory.ToLower().Replace(" ", "-");
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var divs = doc.DocumentNode.SelectNodes("//div[contains(@class,'flyer-run see-more ')]");
            foreach (HtmlNode div in divs)
            {
                var link = div.InnerHtml.Replace("#!/", "|").Split('|')[1];
                link = link.Replace("\" onclick=\"", "|").Split('|')[0];
                link = link.Replace("flyers/", "https://www.flyertown.ca/d/flyer_data/") + "&p=flyertown";
                result.Add(link);
            }
            return result;
        }
        public static string MerchantCode(string flyerUrl){
            var flyer = flyerUrl.Split('?')[0];
            var x =  flyer.Split('/');
            var result = x[x.Length -1].Split('-')[0];
            return result;
            

        }
    }
}