using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.APIModel.Achievement
{
    public class Achievement
    {
        public bool accountWide { get; set; }
        public List<Criterion> criteria { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public int id { get; set; }
        public int points { get; set; }
        public string reward { get; set; }
        public List<RewardItem> rewardItems { get; set; }
        public string title { get; set; }
    }

    public class Criterion
    {
        public string description { get; set; }
        public int id { get; set; }
        public int max { get; set; }
        public int orderIndex { get; set; }
    }

    public class TooltipParams
    {
    }

    public class RewardItem
    {
        public string icon { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int quality { get; set; }
        public TooltipParams tooltipParams { get; set; }
    }
}
