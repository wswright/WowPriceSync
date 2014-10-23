using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.APIModel.CharacterProfessions
{
    public class CharacterProfessions
    {
        public int achievementPoints { get; set; }
        public string battlegroup { get; set; }
        public string calcClass { get; set; }
        public int @class { get; set; }
        public int gender { get; set; }
        public long lastModified { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public Professions professions { get; set; }
        public int race { get; set; }
        public string realm { get; set; }
        public string thumbnail { get; set; }
    }

    public class Primary
    {
        public string icon { get; set; }
        public int id { get; set; }
        public int max { get; set; }
        public string name { get; set; }
        public int rank { get; set; }
        public List<int> recipes { get; set; }
    }

    public class Secondary
    {
        public string icon { get; set; }
        public int id { get; set; }
        public int max { get; set; }
        public string name { get; set; }
        public int rank { get; set; }
        public List<object> recipes { get; set; }
    }

    public class Professions
    {
        public List<Primary> primary { get; set; }
        public List<Secondary> secondary { get; set; }
    }
}
