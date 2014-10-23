using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.APIModel.CharacterProgression
{
    public class CharacterProgression
    {
        public int achievementPoints { get; set; }
        public string battlegroup { get; set; }
        public string calcClass { get; set; }
        public int @class { get; set; }
        public int gender { get; set; }
        public long lastModified { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public Progression progression { get; set; }
        public int race { get; set; }
        public string realm { get; set; }
        public string thumbnail { get; set; }
    }

    public class Boss
    {
        public int heroicKills { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int normalKills { get; set; }
    }

    public class Raid
    {
        public List<Boss> bosses { get; set; }
        public int heroic { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int normal { get; set; }
    }

    public class Progression
    {
        public List<Raid> raids { get; set; }
    }
}
