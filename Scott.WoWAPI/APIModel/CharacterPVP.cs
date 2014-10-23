using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.APIModel.CharacterPVP
{
    public class CharacterPVP
    {
        public int achievementPoints { get; set; }
        public string battlegroup { get; set; }
        public string calcClass { get; set; }
        public int @class { get; set; }
        public int gender { get; set; }
        public long lastModified { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public Pvp pvp { get; set; }
        public int race { get; set; }
        public string realm { get; set; }
        public string thumbnail { get; set; }
    }

    public class Battleground
    {
        public string name { get; set; }
        public int played { get; set; }
        public int won { get; set; }
    }

    public class RatedBattlegrounds
    {
        public List<Battleground> battlegrounds { get; set; }
        public int personalRating { get; set; }
    }

    public class Pvp
    {
        public List<object> arenaTeams { get; set; }
        public RatedBattlegrounds ratedBattlegrounds { get; set; }
        public int totalHonorableKills { get; set; }
    }
}
