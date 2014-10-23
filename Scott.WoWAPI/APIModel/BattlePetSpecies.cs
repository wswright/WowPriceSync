using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.APIModel.BattlePetSpecies
{
    public class BattlePetSpecies
    {
        public List<Ability> abilities { get; set; }
        public bool canBattle { get; set; }
        public int creatureId { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public int petTypeId { get; set; }
        public string source { get; set; }
        public int speciesId { get; set; }
    }

    public class Ability
    {
        public int cooldown { get; set; }
        public string icon { get; set; }
        public int id { get; set; }
        public bool isPassive { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public int petTypeId { get; set; }
        public int requiredLevel { get; set; }
        public int rounds { get; set; }
        public bool showHints { get; set; }
        public int slot { get; set; }
    }
}
