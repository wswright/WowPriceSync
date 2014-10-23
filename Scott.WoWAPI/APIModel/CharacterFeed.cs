using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.APIModel.CharacterFeed
{
    public class CharacterFeed
    {
        public int achievementPoints { get; set; }
        public string battlegroup { get; set; }
        public string calcClass { get; set; }
        public int @class { get; set; }
        public List<Feed> feed { get; set; }
        public int gender { get; set; }
        public long lastModified { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public int race { get; set; }
        public string realm { get; set; }
        public string thumbnail { get; set; }
    }

    public class Achievement
    {
        public bool accountWide { get; set; }
        public List<object> criteria { get; set; }
        public string description { get; set; }
        public int factionId { get; set; }
        public string icon { get; set; }
        public int id { get; set; }
        public int points { get; set; }
        public List<object> rewardItems { get; set; }
        public string title { get; set; }
        public string reward { get; set; }
    }

    public class Criteria
    {
        public string description { get; set; }
        public int id { get; set; }
        public int max { get; set; }
        public int orderIndex { get; set; }
    }

    public class Feed
    {
        public Achievement achievement { get; set; }
        public bool featOfStrength { get; set; }
        public object timestamp { get; set; }
        public string type { get; set; }
        public Criteria criteria { get; set; }
        public string name { get; set; }
        public int? quantity { get; set; }
        public int? itemId { get; set; }
    }
}
