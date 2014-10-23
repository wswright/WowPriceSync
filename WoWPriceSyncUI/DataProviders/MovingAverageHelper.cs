using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace WoWPriceSyncUI.DataProviders
{
    public class MovingAverageHelper
    {
        public const int DEFAULT_MAX_POINTS = 48;
        private int maxPoints = DEFAULT_MAX_POINTS;

        private Queue<double> points;
        private IEnumerable<TimeValueEntry> _values;


        public MovingAverageHelper(IEnumerable<TimeValueEntry> values, int numPointsPerSample = DEFAULT_MAX_POINTS)
        {
            points = new Queue<double>(numPointsPerSample);
            maxPoints = numPointsPerSample;
            _values = values;
        }

        public PointPairList Calculate()
        {
            PointPairList ppl = new PointPairList();

            foreach (TimeValueEntry entry in _values.OrderBy(a => a.time))
            {
                points.Enqueue(entry.value);
                ppl.Add(CalculatePointPair(entry));
                if (points.Count > maxPoints)
                    points.Dequeue();
            }
            return ppl;
        }

        private PointPair CalculatePointPair(TimeValueEntry entry)
        {
            double avg = points.Average();
            PointPair pp = new PointPair(entry.time.ToOADate(), avg);
            return pp;
        }
    }
}
