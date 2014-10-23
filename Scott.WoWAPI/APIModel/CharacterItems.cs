using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.APIModel.CharacterItems
{
    public class CharacterItems
    {
        public int achievementPoints { get; set; }
        public string battlegroup { get; set; }
        public string calcClass { get; set; }
        public int @class { get; set; }
        public int gender { get; set; }
        public Items items { get; set; }
        public long lastModified { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public int race { get; set; }
        public string realm { get; set; }
        public string thumbnail { get; set; }
    }

    public class TooltipParams
    {
    }

    public class Back
    {
        public string icon { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int quality { get; set; }
        public TooltipParams tooltipParams { get; set; }
    }

    public class TooltipParams2
    {
        public int reforge { get; set; }
    }

    public class Chest
    {
        public string icon { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int quality { get; set; }
        public TooltipParams2 tooltipParams { get; set; }
    }

    public class TooltipParams3
    {
    }

    public class Feet
    {
        public string icon { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int quality { get; set; }
        public TooltipParams3 tooltipParams { get; set; }
    }

    public class TooltipParams4
    {
    }

    public class Finger1
    {
        public string icon { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int quality { get; set; }
        public TooltipParams4 tooltipParams { get; set; }
    }

    public class TooltipParams5
    {
    }

    public class Finger2
    {
        public string icon { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int quality { get; set; }
        public TooltipParams5 tooltipParams { get; set; }
    }

    public class TooltipParams6
    {
    }

    public class Hands
    {
        public string icon { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int quality { get; set; }
        public TooltipParams6 tooltipParams { get; set; }
    }

    public class TooltipParams7
    {
    }

    public class Legs
    {
        public string icon { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int quality { get; set; }
        public TooltipParams7 tooltipParams { get; set; }
    }

    public class TooltipParams8
    {
    }

    public class MainHand
    {
        public string icon { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int quality { get; set; }
        public TooltipParams8 tooltipParams { get; set; }
    }

    public class TooltipParams9
    {
    }

    public class Neck
    {
        public string icon { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int quality { get; set; }
        public TooltipParams9 tooltipParams { get; set; }
    }

    public class TooltipParams10
    {
    }

    public class Shoulder
    {
        public string icon { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int quality { get; set; }
        public TooltipParams10 tooltipParams { get; set; }
    }

    public class TooltipParams11
    {
    }

    public class Trinket1
    {
        public string icon { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int quality { get; set; }
        public TooltipParams11 tooltipParams { get; set; }
    }

    public class TooltipParams12
    {
    }

    public class Trinket2
    {
        public string icon { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int quality { get; set; }
        public TooltipParams12 tooltipParams { get; set; }
    }

    public class TooltipParams13
    {
    }

    public class Waist
    {
        public string icon { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int quality { get; set; }
        public TooltipParams13 tooltipParams { get; set; }
    }

    public class TooltipParams14
    {
    }

    public class Wrist
    {
        public string icon { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int quality { get; set; }
        public TooltipParams14 tooltipParams { get; set; }
    }

    public class Items
    {
        public int averageItemLevel { get; set; }
        public int averageItemLevelEquipped { get; set; }
        public Back back { get; set; }
        public Chest chest { get; set; }
        public Feet feet { get; set; }
        public Finger1 finger1 { get; set; }
        public Finger2 finger2 { get; set; }
        public Hands hands { get; set; }
        public Legs legs { get; set; }
        public MainHand mainHand { get; set; }
        public Neck neck { get; set; }
        public Shoulder shoulder { get; set; }
        public Trinket1 trinket1 { get; set; }
        public Trinket2 trinket2 { get; set; }
        public Waist waist { get; set; }
        public Wrist wrist { get; set; }
    }
}
