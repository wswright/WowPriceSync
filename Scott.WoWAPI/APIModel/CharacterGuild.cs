using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.APIModel.CharacterGuild
{
    public class CharacterGuild
    {
        public int achievementPoints { get; set; }
        public string battlegroup { get; set; }
        public string calcClass { get; set; }
        public int @class { get; set; }
        public int gender { get; set; }
        public Guild guild { get; set; }
        public long lastModified { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public int race { get; set; }
        public string realm { get; set; }
        public string thumbnail { get; set; }
    }

    public class Emblem
    {
        public string backgroundColor { get; set; }
        public int border { get; set; }
        public string borderColor { get; set; }
        public int icon { get; set; }
        public string iconColor { get; set; }
    }

    public class Guild
    {
        public int achievementPoints { get; set; }
        public string battlegroup { get; set; }
        public Emblem emblem { get; set; }
        public int level { get; set; }
        public int members { get; set; }
        public string name { get; set; }
        public string realm { get; set; }
    }
}
