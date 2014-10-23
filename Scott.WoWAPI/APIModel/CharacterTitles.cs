using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.APIModel
{
    public class CharacterTitles
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
        public string thumbnail { get; set; }
        public List<Title> titles { get; set; }
    }

    public class Title
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool selected { get; set; }
    }
}
