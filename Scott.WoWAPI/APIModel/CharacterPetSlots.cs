using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.APIModel.CharacterPetSlots
{
    public class CharacterPetSlots
    {
        public int achievementPoints { get; set; }
        public string battlegroup { get; set; }
        public string calcClass { get; set; }
        public int @class { get; set; }
        public int gender { get; set; }
        public long lastModified { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public List<PetSlot> petSlots { get; set; }
        public int race { get; set; }
        public string realm { get; set; }
        public string thumbnail { get; set; }
    }

    public class PetSlot
    {
        public List<object> abilities { get; set; }
        public int battlePetId { get; set; }
        public bool isEmpty { get; set; }
        public bool isLocked { get; set; }
        public int slot { get; set; }
    }
}
