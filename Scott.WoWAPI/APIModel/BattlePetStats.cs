using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.APIModel.BattlePetStats
{
    public class BattlePetStats
    {
        public int breedId { get; set; }
        public int health { get; set; }
        public int level { get; set; }
        public int petQualityId { get; set; }
        public int power { get; set; }
        public int speciesId { get; set; }
        public int speed { get; set; }
    }
}
