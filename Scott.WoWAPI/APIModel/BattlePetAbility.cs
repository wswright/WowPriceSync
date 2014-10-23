using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.APIModel.BattlePetAbility
{
    public class BattlePetAbility
    {
        public int cooldown { get; set; }
        public string icon { get; set; }
        public int id { get; set; }
        public bool isPassive { get; set; }
        public string name { get; set; }
        public int petTypeId { get; set; }
        public int rounds { get; set; }
        public bool showHints { get; set; }

    }
}
