using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace WoWPriceSyncUI.DataProviders
{
    /// <summary>
    /// Defines a Data Curve with a PointPairList and supporting properties.
    /// </summary>
    public class DataCurveDescriptor
    {
        public bool DoFill;
        public bool DoAntiAlias;
        public string Title;
        public float LineWidth = 1.0F;
        public PointPairList pointList;
        public SymbolType Symbol = SymbolType.None;

        public DataCurveDescriptor(PointPairList ppList)
        {
            pointList = ppList;
        }

        public DataCurveDescriptor()
        {
            pointList = new PointPairList();
        }
    }
}
