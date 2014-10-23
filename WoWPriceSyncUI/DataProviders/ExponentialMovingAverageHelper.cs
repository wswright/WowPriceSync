using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace WoWPriceSyncUI.DataProviders
{
    public class ExponentialMovingAverageHelper
    {
        public const int DEFAULT_NUMBER_OF_POINTS = 22;
        private int maxPoints = DEFAULT_NUMBER_OF_POINTS;

        private Queue<double> points;
        private IEnumerable<TimeValueEntry> _values;

        public ExponentialMovingAverageHelper(IEnumerable<TimeValueEntry> values, int numPoints = DEFAULT_NUMBER_OF_POINTS)
        {
            points = new Queue<double>(numPoints);
            maxPoints = numPoints;
            _values = values;
        }

        public PointPairList Calculate()
        {
            PointPairList ppl = new PointPairList();
            double previousEMA = 0.0;
            int index = 0;
            foreach (TimeValueEntry entry in _values.OrderBy(a => a.time))
            {
                //Skip the first maxPoints # of values. They are used to seed the first EMA, which is maxPoints+1 entries in
                if (index < maxPoints)
                {
                    points.Enqueue(entry.value);
                    index++;
                    continue;
                }

                if (index == maxPoints)
                {
                    previousEMA = points.Average();
                }

                double currentEMA = CalculateEMA(entry.value, maxPoints, previousEMA);
                ppl.Add(CalculatePointPair(entry.time, currentEMA));
                previousEMA = currentEMA;
                index++;
            }
            return ppl;
        }

        /// <summary>
        /// Calculates the Exponential Moving Average for a given day.
        /// http://www.iexplain.org/ema-how-to-calculate/
        /// </summary>
        /// <param name="currentPrice">The current price.</param>
        /// <param name="numDays">The number of days for the EMA.</param>
        /// <param name="previousEMA">The previous EMA. (Previous hour, previous day, previous entry)</param>
        /// <returns></returns>
        private double CalculateEMA(double currentPrice, int numDays, double previousEMA)
        {
            double k = 2.0 / (numDays + 1.0);
            return currentPrice * k + previousEMA * (1.0 - k);
        }

        private PointPair CalculatePointPair(DateTime time, double EMA)
        {
            double avg = points.Average();
            PointPair pp = new PointPair(time.ToOADate(), EMA);
            return pp;
        }
    }
}
