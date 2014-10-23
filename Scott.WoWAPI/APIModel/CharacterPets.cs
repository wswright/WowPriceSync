using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.APIModel.CharacterPets
{
    public class CharacterPets
    {
        public int achievementPoints { get; set; }
        public string battlegroup { get; set; }
        public string calcClass { get; set; }
        public int @class { get; set; }
        public int gender { get; set; }
        public long lastModified { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public Pets pets { get; set; }
        public int race { get; set; }
        public string realm { get; set; }
        public string thumbnail { get; set; }
    }

    public class Stats
    {
        public int breedId { get; set; }
        public int health { get; set; }
        public int level { get; set; }
        public int petQualityId { get; set; }
        public int power { get; set; }
        public int speciesId { get; set; }
        public int speed { get; set; }
    }

    public class Collected
    {
        public int battlePetId { get; set; }
        public bool canBattle { get; set; }
        public int creatureId { get; set; }
        public string creatureName { get; set; }
        public string icon { get; set; }
        public bool isFavorite { get; set; }
        public int itemId { get; set; }
        public string name { get; set; }
        public int qualityId { get; set; }
        public int spellId { get; set; }
        public Stats stats { get; set; }
    }

    public class Pets
    {
        public List<Collected> collected { get; set; }
        public int numCollected { get; set; }
        public int numNotCollected { get; set; }
    }
}
