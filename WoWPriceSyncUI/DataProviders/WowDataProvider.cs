using Scott.WoWAPI;
using Scott.WoWAPI.APIModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace WoWPriceSyncUI.DataProviders
{
    public abstract class WowDataProvider
    {
        public enum Faction { Alliance, Horde, Neutral };
        protected Faction[] _factions;

        public abstract Item GetItem();

        [CategoryAttribute("DataProvider")]
        public Faction[] Factions
        {
            get
            {
                return _factions;
            }
            set
            {
                _factions = value;
            }
        }

        public abstract string GetTitle();
        public abstract string GetXAxisTitle();
        public abstract string GetYAxisTitle();
        public abstract AxisType GetXAxisType();
        
        
        public WowDataProvider()
        {
            _factions = new Faction[3]{
                Faction.Alliance, 
                Faction.Horde, 
                Faction.Neutral
            };
        }

        /// <summary>
        /// Sets the factions for the data provider.
        /// Clears existing factions and sets the given factions.
        /// </summary>
        /// <param name="pFactions"></param>
        public void SetFactions(params Faction[] pFactions)
        {
            var distinctFactions = (from f in pFactions
                                    select f).Distinct();
            _factions = distinctFactions.ToArray();
            RefreshData();
        }

        protected string[] GetFactionCodes()
        {
            List<string> factionCodes = new List<string>();
            foreach (Faction f in _factions)
                factionCodes.Add(GetFactionCode(f));
            return factionCodes.ToArray();
        }

        protected string GetFactionCode(Faction f)
        {
            switch (f)
            {
                case Faction.Alliance:
                    return "a";
                case Faction.Horde:
                    return "h";
                case Faction.Neutral:
                    return "n";
                default:
                    throw new ArgumentOutOfRangeException("f");
            }
        }

        public abstract Task RefreshData();
        public abstract Task<DataCurveDescriptor[]> GetData();
        public abstract string GetCategoryName();

        public virtual void PropertyChanged(object sender, PropertyValueChangedEventArgs e)
        {

        }
    }
}
