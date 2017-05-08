using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NewLeafWebScraper.Items;
using ScrapySharp;
using ScrapySharp.Extensions;

namespace NewLeafWebScraper.Scrape
{
    public static class Scraper
    {
        public static List<Item> ScrapeAll()
        {
            var ret = new List<Item>();
            ret.AddRange(FishScraper.Scrape());
            ret.AddRange(BugScraper.Scrape());
            ret.AddRange(DeepSeaCreaturesScraper.Scrape());

            return ret;
        }

        public static readonly List<string> MonthNames = new List<string> {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
    }

    public static class FishScraper
    {
        public static List<Item> Scrape()
        {
            var web = new HtmlWeb();
            HtmlDocument doc = web.Load("http://animalcrossing.wikia.com/wiki/Fish_(New_Leaf)");

            HtmlNodeCollection fishTable = doc.DocumentNode.SelectNodes("//table")[2].SelectNodes("tr");
            fishTable.RemoveAt(0);

            var fishList = new List<Item>();
            foreach (HtmlNode row in fishTable)
            {
                HtmlNodeCollection columns = row.SelectNodes("td");

                var fish = new Item
                {
                    ItemType = ItemType.Fish,
                    Name = columns[0].SelectSingleNode("a").InnerText.Trim(),
                    Key = columns[0].SelectSingleNode("a").InnerText.ToLower().RemoveAllWhitespace(),
                    Price = int.Parse(columns[2].InnerText.Trim().Replace(",", string.Empty)),
                    Location = columns[3].InnerText.Trim(),
                    IslandAvailability =
                        columns[3].InnerHtml.Contains("Redhibiscusacnl")
                            ? IslandAvailability.Shared
                            : columns[3].InnerHtml.Contains("Yellowhibiscusacnl")
                                ? IslandAvailability.Exclusive
                                : IslandAvailability.None,
                    ShadowSize = columns[4].InnerText.Trim(),
                    Time = columns[5].InnerText.Trim(),
                    Months = new List<string>()
                };

                for (var i = 0; i < 12; i++)
                {
                    if (columns[i + 6].InnerText.Trim() == "✓")
                    {
                        fish.Months.Add(Scraper.MonthNames[i]);
                    }
                }

                fishList.Add(fish);
            }

            return fishList;
        }
    }

    public static class BugScraper
    {
        public static List<Item> Scrape()
        {
            var web = new HtmlWeb();
            HtmlDocument doc = web.Load("http://animalcrossing.wikia.com/wiki/Bugs_(New_Leaf)");

            HtmlNodeCollection bugTable = doc.DocumentNode.SelectNodes("//table")[2].SelectNodes("tr");
            bugTable.RemoveAt(0);

            var bugList = new List<Item>();
            foreach (HtmlNode row in bugTable)
            {
                HtmlNodeCollection columns = row.SelectNodes("td");

                var bug = new Item
                {
                    ItemType = ItemType.Bug,
                    Name = columns[0].SelectSingleNode("a").InnerText.Trim(),
                    Key = columns[0].SelectSingleNode("a").InnerText.ToLower().RemoveAllWhitespace(),
                    Price = int.Parse(columns[2].InnerText.Trim().Replace(",", string.Empty)),
                    Location = columns[3].InnerText.Trim(),
                    IslandAvailability =
                        columns[3].InnerHtml.Contains("Redhibiscusacnl")
                            ? IslandAvailability.Shared
                            : columns[3].InnerHtml.Contains("Yellowhibiscusacnl")
                                ? IslandAvailability.Exclusive
                                : IslandAvailability.None,
                    Time = columns[4].InnerText.Trim(),
                    Months = new List<string>()
                };

                for (var i = 0; i < 12; i++)
                {
                    if (columns[i + 5].InnerText.Trim() == "✓")
                    {
                        bug.Months.Add(Scraper.MonthNames[i]);
                    }
                }

                bugList.Add(bug);
            }

            return bugList;
        }
    }

    public static class DeepSeaCreaturesScraper
    {
        public static List<Item> Scrape()
        {
            var web = new HtmlWeb();
            HtmlDocument doc = web.Load("http://animalcrossing.wikia.com/wiki/Deep-Sea_Creatures");

            HtmlNodeCollection creatureTable = doc.DocumentNode.SelectNodes("//table")[2].SelectNodes("tr");
            creatureTable.RemoveAt(0);

            var creatureList = new List<Item>();
            foreach (HtmlNode row in creatureTable)
            {
                HtmlNodeCollection columns = row.SelectNodes("td");

                var creature = new Item
                {
                    ItemType = ItemType.DeepSeaCreature,
                    Name = columns[0].SelectSingleNode("a").InnerText.Trim(),
                    Key = columns[0].SelectSingleNode("a").InnerText.ToLower().RemoveAllWhitespace(),
                    Price = int.Parse(columns[2].InnerText.Trim().Replace(",", string.Empty)),
                    Location = "on the ocean floor",
                    IslandAvailability =
                        columns[3].InnerHtml.Contains("Redhibiscusacnl")
                            ? IslandAvailability.Shared
                            : columns[3].InnerHtml.Contains("Yellowhibiscusacnl")
                                ? IslandAvailability.Exclusive
                                : IslandAvailability.None,
                    ShadowSize = columns[3].InnerText.Trim(),
                    Time = columns[4].InnerText.Trim(),
                    Months = new List<string>()
                };

                for (var i = 0; i < 12; i++)
                {
                    if (columns[i + 5].InnerText.Trim() == "✓")
                    {
                        creature.Months.Add(Scraper.MonthNames[i]);
                    }
                }

                creatureList.Add(creature);
            }

            return creatureList;
        }
    }
}
