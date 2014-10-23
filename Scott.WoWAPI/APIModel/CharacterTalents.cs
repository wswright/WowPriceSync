using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.APIModel.CharacterTalents
{
    public class CharacterTalents
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
        public List<Talent> talents { get; set; }
        public string thumbnail { get; set; }
    }

    public class Glyphs
    {
        public List<object> major { get; set; }
        public List<object> minor { get; set; }
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

    public class Talent
    {
        public string calcGlyph { get; set; }
        public string calcSpec { get; set; }
        public string calcTalent { get; set; }
        public Glyphs glyphs { get; set; }
        public bool selected { get; set; }
        public Spec spec { get; set; }
        public List<object> talents { get; set; }
    }
}
