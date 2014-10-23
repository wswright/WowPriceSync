using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI
{
    public class RealmInfo
    {
        public static Dictionary<string, string> RealmList;

        public string Realm
        { 
            get
            {
                return _Realm;   
            }

            set
            {
                if (VerifyRealmName(value))
                {
                    _Realm = value;
                    Slug = RealmList[value];
                }
                else
                {
                    //Couldn't match the Realm name. Maybe this is a slug instead
                    if (IsSlug(value))
                    {
                        Slug = value;
                        _Realm = GetRealmNameForSlug(value);
                    }
                    else
                        throw new ArgumentOutOfRangeException("Realm", "Invalid Realm Name!");
                }
            }
        }

        private string _Realm;
        private string Slug;

        /// <summary>
        /// Determines if the given realm name is a valid realm name. Case insensitive.
        /// </summary>
        /// <param name="realmName">The realm name.</param>
        /// <returns>True if the realm name is valid, otherwise returns false.</returns>
        private bool VerifyRealmName(string realmName)
        {
            if (string.IsNullOrWhiteSpace(realmName))
                return false;

            string tmp = realmName.ToLower().Trim();
            foreach(KeyValuePair<string, string> kvp in RealmList)
            {
                if (kvp.Key.ToLower().Equals(tmp))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Determines if the given realm name is a slug instead of a proper Realm Name.
        /// </summary>
        /// <param name="realmName">The realm name.</param>
        /// <returns>True if the realm name is a slug, otherwise returns false.</returns>
        private bool IsSlug(string realmName)
        {
            if (string.IsNullOrWhiteSpace(realmName))
                return false;

            string tmp = realmName.ToLower().Trim();
            foreach (string slug in RealmList.Values)
            {
                if (slug.Equals(tmp))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the realm name that corresponds to the given slug.
        /// </summary>
        /// <param name="slug">The realm name slug.</param>
        /// <returns>The realm name for the given slug. Throws ArgumentOutOfRangeException if the slug doesn't exist.</returns>
        private string GetRealmNameForSlug(string slug)
        {
            foreach (KeyValuePair<string, string> kvp in RealmList)
            {
                if (kvp.Value.Equals(slug))
                    return kvp.Key;
            }
            throw new ArgumentOutOfRangeException("slug", "Invalid realm slug!");
        }

        static RealmInfo()
        {
            //Create the list of Realm names and corresponding slugs statically
            RealmList = new Dictionary<string, string>
            {
                {"Aegwynn", "aegwynn"},
                {"Aerie Peak", "aerie-peak"},
                {"Agamaggan", "agamaggan"},
                {"Aggramar", "aggramar"},
                {"Akama", "akama"},
                {"Alexstrasza", "alexstrasza"},
                {"Alleria", "alleria"},
                {"Altar of Storms", "altar-of-storms"},
                {"Alterac Mountains", "alterac-mountains"},
                {"Aman'Thul", "amanthul"},
                {"Andorhal", "andorhal"},
                {"Anetheron", "anetheron"},
                {"Antonidas", "antonidas"},
                {"Anub'arak", "anubarak"},
                {"Anvilmar", "anvilmar"},
                {"Arathor", "arathor"},
                {"Archimonde", "archimonde"},
                {"Area 52", "area-52"},
                {"Argent Dawn", "argent-dawn"},
                {"Arthas", "arthas"},
                {"Arygos", "arygos"},
                {"Auchindoun", "auchindoun"},
                {"Azgalor", "azgalor"},
                {"Azjol-Nerub", "azjolnerub"},
                {"Azralon", "azralon"},
                {"Azshara", "azshara"},
                {"Azuremyst", "azuremyst"},
                {"Baelgun", "baelgun"},
                {"Balnazzar", "balnazzar"},
                {"Barthilas", "barthilas"},
                {"Black Dragonflight", "black-dragonflight"},
                {"Blackhand", "blackhand"},
                {"Blackrock", "blackrock"},
                {"Blackwater Raiders", "blackwater-raiders"},
                {"Blackwing Lair", "blackwing-lair"},
                {"Blade's Edge", "blades-edge"},
                {"Bladefist", "bladefist"},
                {"Bleeding Hollow", "bleeding-hollow"},
                {"Blood Furnace", "blood-furnace"},
                {"Bloodhoof", "bloodhoof"},
                {"Bloodscalp", "bloodscalp"},
                {"Bonechewer", "bonechewer"},
                {"Borean Tundra", "borean-tundra"},
                {"Boulderfist", "boulderfist"},
                {"Bronzebeard", "bronzebeard"},
                {"Burning Blade", "burning-blade"},
                {"Burning Legion", "burning-legion"},
                {"Caelestrasz", "caelestrasz"},
                {"Cairne", "cairne"},
                {"Cenarion Circle", "cenarion-circle"},
                {"Cenarius", "cenarius"},
                {"Cho'gall", "chogall"},
                {"Chromaggus", "chromaggus"},
                {"Coilfang", "coilfang"},
                {"Crushridge", "crushridge"},
                {"Daggerspine", "daggerspine"},
                {"Dalaran", "dalaran"},
                {"Dalvengyr", "dalvengyr"},
                {"Dark Iron", "dark-iron"},
                {"Darkspear", "darkspear"},
                {"Darrowmere", "darrowmere"},
                {"Dath'Remar", "dathremar"},
                {"Dawnbringer", "dawnbringer"},
                {"Deathwing", "deathwing"},
                {"Demon Soul", "demon-soul"},
                {"Dentarg", "dentarg"},
                {"Destromath", "destromath"},
                {"Dethecus", "dethecus"},
                {"Detheroc", "detheroc"},
                {"Doomhammer", "doomhammer"},
                {"Draenor", "draenor"},
                {"Dragonblight", "dragonblight"},
                {"Dragonmaw", "dragonmaw"},
                {"Drak'Tharon", "draktharon"},
                {"Drak'thul", "drakthul"},
                {"Draka", "draka"},
                {"Drakkari", "drakkari"},
                {"Dreadmaul", "dreadmaul"},
                {"Drenden", "drenden"},
                {"Dunemaul", "dunemaul"},
                {"Durotan", "durotan"},
                {"Duskwood", "duskwood"},
                {"Earthen Ring", "earthen-ring"},
                {"Echo Isles", "echo-isles"},
                {"Eitrigg", "eitrigg"},
                {"Eldre'Thalas", "eldrethalas"},
                {"Elune", "elune"},
                {"Emerald Dream", "emerald-dream"},
                {"Eonar", "eonar"},
                {"Eredar", "eredar"},
                {"Executus", "executus"},
                {"Exodar", "exodar"},
                {"Farstriders", "farstriders"},
                {"Feathermoon", "feathermoon"},
                {"Fenris", "fenris"},
                {"Firetree", "firetree"},
                {"Fizzcrank", "fizzcrank"},
                {"Frostmane", "frostmane"},
                {"Frostmourne", "frostmourne"},
                {"Frostwolf", "frostwolf"},
                {"Galakrond", "galakrond"},
                {"Gallywix", "gallywix"},
                {"Garithos", "garithos"},
                {"Garona", "garona"},
                {"Garrosh", "garrosh"},
                {"Ghostlands", "ghostlands"},
                {"Gilneas", "gilneas"},
                {"Gnomeregan", "gnomeregan"},
                {"Goldrinn", "goldrinn"},
                {"Gorefiend", "gorefiend"},
                {"Gorgonnash", "gorgonnash"},
                {"Greymane", "greymane"},
                {"Grizzly Hills", "grizzly-hills"},
                {"Gul'dan", "guldan"},
                {"Gundrak", "gundrak"},
                {"Gurubashi", "gurubashi"},
                {"Hakkar", "hakkar"},
                {"Haomarush", "haomarush"},
                {"Hellscream", "hellscream"},
                {"Hydraxis", "hydraxis"},
                {"Hyjal", "hyjal"},
                {"Icecrown", "icecrown"},
                {"Illidan", "illidan"},
                {"Jaedenar", "jaedenar"},
                {"Jubei'Thos", "jubeithos"},
                {"Kael'thas", "kaelthas"},
                {"Kalecgos", "kalecgos"},
                {"Kargath", "kargath"},
                {"Kel'Thuzad", "kelthuzad"},
                {"Khadgar", "khadgar"},
                {"Khaz Modan", "khaz-modan"},
                {"Khaz'goroth", "khazgoroth"},
                {"Kil'jaeden", "kiljaeden"},
                {"Kilrogg", "kilrogg"},
                {"Kirin Tor", "kirin-tor"},
                {"Korgath", "korgath"},
                {"Korialstrasz", "korialstrasz"},
                {"Kul Tiras", "kul-tiras"},
                {"Laughing Skull", "laughing-skull"},
                {"Lethon", "lethon"},
                {"Lightbringer", "lightbringer"},
                {"Lightning's Blade", "lightnings-blade"},
                {"Lightninghoof", "lightninghoof"},
                {"Llane", "llane"},
                {"Lothar", "lothar"},
                {"Madoran", "madoran"},
                {"Maelstrom", "maelstrom"},
                {"Magtheridon", "magtheridon"},
                {"Maiev", "maiev"},
                {"Mal'Ganis", "malganis"},
                {"Malfurion", "malfurion"},
                {"Malorne", "malorne"},
                {"Malygos", "malygos"},
                {"Mannoroth", "mannoroth"},
                {"Medivh", "medivh"},
                {"Misha", "misha"},
                {"Mok'Nathal", "moknathal"},
                {"Moon Guard", "moon-guard"},
                {"Moonrunner", "moonrunner"},
                {"Mug'thol", "mugthol"},
                {"Muradin", "muradin"},
                {"Nagrand", "nagrand"},
                {"Nathrezim", "nathrezim"},
                {"Nazgrel", "nazgrel"},
                {"Nazjatar", "nazjatar"},
                {"Nemesis", "nemesis"},
                {"Ner'zhul", "nerzhul"},
                {"Nesingwary", "nesingwary"},
                {"Nordrassil", "nordrassil"},
                {"Norgannon", "norgannon"},
                {"Onyxia", "onyxia"},
                {"Perenolde", "perenolde"},
                {"Proudmoore", "proudmoore"},
                {"Quel'Thalas", "quelthalas"},
                {"Quel'dorei", "queldorei"},
                {"Ragnaros", "ragnaros"},
                {"Ravencrest", "ravencrest"},
                {"Ravenholdt", "ravenholdt"},
                {"Rexxar", "rexxar"},
                {"Rivendare", "rivendare"},
                {"Runetotem", "runetotem"},
                {"Sargeras", "sargeras"},
                {"Saurfang", "saurfang"},
                {"Scarlet Crusade", "scarlet-crusade"},
                {"Scilla", "scilla"},
                {"Sen'jin", "senjin"},
                {"Sentinels", "sentinels"},
                {"Shadow Council", "shadow-council"},
                {"Shadowmoon", "shadowmoon"},
                {"Shadowsong", "shadowsong"},
                {"Shandris", "shandris"},
                {"Shattered Halls", "shattered-halls"},
                {"Shattered Hand", "shattered-hand"},
                {"Shu'halo", "shuhalo"},
                {"Silver Hand", "silver-hand"},
                {"Silvermoon", "silvermoon"},
                {"Sisters of Elune", "sisters-of-elune"},
                {"Skullcrusher", "skullcrusher"},
                {"Skywall", "skywall"},
                {"Smolderthorn", "smolderthorn"},
                {"Spinebreaker", "spinebreaker"},
                {"Spirestone", "spirestone"},
                {"Staghelm", "staghelm"},
                {"Steamwheedle Cartel","steamwheedle-cartel"},
                {"Stonemaul", "stonemaul"},
                {"Stormrage", "stormrage"},
                {"Stormreaver", "stormreaver"},
                {"Stormscale", "stormscale"},
                {"Suramar", "suramar"},
                {"Tanaris", "tanaris"},
                {"Terenas", "terenas"},
                {"Terokkar", "terokkar"},
                {"Thaurissan", "thaurissan"},
                {"The Forgotten Coast","the-forgotten-coast"},
                {"The Scryers", "the-scryers"},
                {"The Underbog", "the-underbog"},
                {"The Venture Co", "the-venture-co"},
                {"Thorium Brotherhood","thorium-brotherhood"},
                {"Thrall", "thrall"},
                {"Thunderhorn", "thunderhorn"},
                {"Thunderlord", "thunderlord"},
                {"Tichondrius", "tichondrius"},
                {"Tol Barad", "tol-barad"},
                {"Tortheldrin", "tortheldrin"},
                {"Trollbane", "trollbane"},
                {"Turalyon", "turalyon"},
                {"Twisting Nether", "twisting-nether"},
                {"Uldaman", "uldaman"},
                {"Uldum", "uldum"},
                {"Undermine", "undermine"},
                {"Ursin", "ursin"},
                {"Uther", "uther"},
                {"Vashj", "vashj"},
                {"Vek'nilash", "veknilash"},
                {"Velen", "velen"},
                {"Warsong", "warsong"},
                {"Whisperwind", "whisperwind"},
                {"Wildhammer", "wildhammer"},
                {"Windrunner", "windrunner"},
                {"Winterhoof", "winterhoof"},
                {"Wyrmrest Accord", "wyrmrest-accord"},
                {"Ysera", "ysera"},
                {"Ysondre", "ysondre"},
                {"Zangarmarsh", "zangarmarsh"},
                {"Zul'jin", "zuljin"},
                {"Zuluhed", "zuluhed"}
            };
        }
    }
}
