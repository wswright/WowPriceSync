using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.APIModel.CharacterStats
{
    public class CharacterStats
    {
        public int achievementPoints { get; set; }
        public string battlegroup { get; set; }
        public string calcClass { get; set; }
        public int @class { get; set; }
        public int gender { get; set; }
        public long lastModified { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public int race { get; set; }
        public string realm { get; set; }
        public Stats stats { get; set; }
        public string thumbnail { get; set; }
    }

    public class Stats
    {
        public int agi { get; set; }
        public int armor { get; set; }
        public int attackPower { get; set; }
        public double block { get; set; }
        public int blockRating { get; set; }
        public double crit { get; set; }
        public int critRating { get; set; }
        public double dodge { get; set; }
        public int dodgeRating { get; set; }
        public int expertiseRating { get; set; }
        public int hasteRating { get; set; }
        public int health { get; set; }
        public double hitPercent { get; set; }
        public int hitRating { get; set; }
        public int @int { get; set; }
        public double mainHandDmgMax { get; set; }
        public double mainHandDmgMin { get; set; }
        public double mainHandDps { get; set; }
        public double mainHandExpertise { get; set; }
        public double mainHandSpeed { get; set; }
        public double mana5 { get; set; }
        public double mana5Combat { get; set; }
        public double mastery { get; set; }
        public int masteryRating { get; set; }
        public double offHandDmgMax { get; set; }
        public double offHandDmgMin { get; set; }
        public double offHandDps { get; set; }
        public double offHandExpertise { get; set; }
        public double offHandSpeed { get; set; }
        public double parry { get; set; }
        public int parryRating { get; set; }
        public int power { get; set; }
        public string powerType { get; set; }
        public double pvpPower { get; set; }
        public int pvpPowerRating { get; set; }
        public double pvpResilience { get; set; }
        public int pvpResilienceRating { get; set; }
        public int rangedAttackPower { get; set; }
        public double rangedCrit { get; set; }
        public int rangedCritRating { get; set; }
        public double rangedDmgMax { get; set; }
        public double rangedDmgMin { get; set; }
        public double rangedDps { get; set; }
        public double rangedExpertise { get; set; }
        public double rangedHitPercent { get; set; }
        public int rangedHitRating { get; set; }
        public double rangedSpeed { get; set; }
        public double spellCrit { get; set; }
        public int spellCritRating { get; set; }
        public double spellHitPercent { get; set; }
        public int spellHitRating { get; set; }
        public int spellPen { get; set; }
        public int spellPower { get; set; }
        public int spr { get; set; }
        public int sta { get; set; }
        public int str { get; set; }
    }
}
