using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.APIModel.CharacterAchievements
{
    public class CharacterAchievements
    {
        public int achievementPoints { get; set; }
        public Achievements achievements { get; set; }
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
    }

    public class Achievements
    {
        public List<int> achievementsCompleted { get; set; }
        public List<object> achievementsCompletedTimestamp { get; set; }
        public List<int> criteria { get; set; }
        public List<object> criteriaCreated { get; set; }
        public List<int> criteriaQuantity { get; set; }
        public List<object> criteriaTimestamp { get; set; }
    }
}
