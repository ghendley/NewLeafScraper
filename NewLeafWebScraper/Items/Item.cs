using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NewLeafWebScraper.Items
{
    [DataContract]
    public class Item
    {
        // All
        [DataMember]
        public string Key { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public ItemType ItemType { get; set; } = ItemType.Other;

        // Most
        [DataMember]
        public int Price { get; set; }

        // Fish & Bugs
        [DataMember]
        public IslandAvailability IslandAvailability { get; set; } = IslandAvailability.None;
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public string Time { get; set; }
        [DataMember]
        public List<string> Months { get; set; }

        // Fish
        [DataMember]
        public string ShadowSize { get; set; }
    }

    [DataContract]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemType
    {
        [DataMember(Name="Other")]
        Other,
        [DataMember(Name = "Fish")]
        Fish,
        [DataMember(Name = "Bug")]
        Bug,
        [DataMember(Name = "Deep Sea Creature")]
        DeepSeaCreature,
        [DataMember(Name = "Fossil")]
        Fossil
    }

    [DataContract]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IslandAvailability
    {
        [DataMember(Name = "None")]
        None,
        [DataMember(Name = "Shared")]
        Shared,
        [DataMember(Name = "Exclusive")]
        Exclusive
    }
}
