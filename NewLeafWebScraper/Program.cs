using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLeafWebScraper.Items;
using NewLeafWebScraper.Scrape;
using Newtonsoft.Json;

namespace NewLeafWebScraper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Item> items = Scraper.ScrapeAll();
            string json = JsonConvert.SerializeObject(items);

            string names = items.Aggregate("", (current, item) => current + (item.Name + "\n"));

            File.WriteAllText(@"C:\Users\William\Dropbox\Projects\AlexaNewLeaf\itemsjson.json", json);
            File.WriteAllText(@"C:\Users\William\Dropbox\Projects\AlexaNewLeaf\speechAssets\itemListSlotType.txt", names);
        }
    }
}
