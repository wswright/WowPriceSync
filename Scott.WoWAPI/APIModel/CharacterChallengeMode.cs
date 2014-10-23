using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.APIModel.CharacterChallengeMode
{
    public class CharacterChallengeMode
    {
        public int achievementPoints { get; set; }
        public string battlegroup { get; set; }
        public string calcClass { get; set; }
        public ChallengeMode challengeMode { get; set; }
        public int @class { get; set; }
        public int gender { get; set; }
        public long lastModified { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public int race { get; set; }
        public string realm { get; set; }
        public string thumbnail { get; set; }
    }

    public class BestTime
    {
        public int hours { get; set; }
        public bool isPositive { get; set; }
        public int milliseconds { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public int time { get; set; }
    }

    public class Diff
    {
        public int hours { get; set; }
        public bool isPositive { get; set; }
        public int milliseconds { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public int time { get; set; }
    }

    public class LastTime
    {
        public int hours { get; set; }
        public bool isPositive { get; set; }
        public int milliseconds { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public int time { get; set; }
    }

    public class BronzeCriteria
    {
        public int hours { get; set; }
        public bool isPositive { get; set; }
        public int milliseconds { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public int time { get; set; }
    }

    public class GoldCriteria
    {
        public int hours { get; set; }
        public bool isPositive { get; set; }
        public int milliseconds { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public int time { get; set; }
    }

    public class SilverCriteria
    {
        public int hours { get; set; }
        public bool isPositive { get; set; }
        public int milliseconds { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public int time { get; set; }
    }

    public class Map
    {
        public BronzeCriteria bronzeCriteria { get; set; }
        public GoldCriteria goldCriteria { get; set; }
        public bool hasChallengeMode { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public SilverCriteria silverCriteria { get; set; }
        public string slug { get; set; }
    }

    public class Record
    {
        public string bestMedal { get; set; }
        public int bestMedalDate { get; set; }
        public BestTime bestTime { get; set; }
        public Diff diff { get; set; }
        public string goal { get; set; }
        public int guildRank { get; set; }
        public LastTime lastTime { get; set; }
        public Map map { get; set; }
        public int realmRank { get; set; }
        public int regionRank { get; set; }
    }

    public class ChallengeMode
    {
        public int bronzeCount { get; set; }
        public int completedCount { get; set; }
        public int goldCount { get; set; }
        public List<Record> records { get; set; }
        public int silverCount { get; set; }
    }
}
