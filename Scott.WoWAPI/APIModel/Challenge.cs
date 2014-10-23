using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.APIModel.Challenge
{
    public class Challenge
    {
        public List<ChallengeObject> challenge { get; set; }
    }

    public class ChallengeObject
    {
        public List<Group> groups { get; set; }
        public Map map { get; set; }
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

    public class Group
    {
        public string date { get; set; }
        public string faction { get; set; }
        public bool isRecurring { get; set; }
        public string medal { get; set; }
        public List<Member> members { get; set; }
        public int ranking { get; set; }
        public Time time { get; set; }
    }

    public class BronzeCriteria
    {
        public int hours { get; set; }
        public int milliseconds { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public int time { get; set; }
    }

    public class GoldCriteria
    {
        public int hours { get; set; }
        public int milliseconds { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public int time { get; set; }
    }

    public class SilverCriteria
    {
        public int hours { get; set; }
        public int milliseconds { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public int time { get; set; }
    }

    public class Spec
    {
        public string backgroundImage { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public string role { get; set; }
    }

    public class Character
    {
        public int achievementPoints { get; set; }
        public string battlegroup { get; set; }
        public int @class { get; set; }
        public int gender { get; set; }
        public string guild { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public int race { get; set; }
        public string realm { get; set; }
        public string thumbnail { get; set; }
        public Spec spec { get; set; }
    }

    public class Spec2
    {
        public string backgroundImage { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public string role { get; set; }
    }

    public class Member
    {
        public Character character { get; set; }
        public Spec2 spec { get; set; }
    }

    public class Time
    {
        public int hours { get; set; }
        public int milliseconds { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public int time { get; set; }
    }
}
