using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWPriceSyncUI
{
    public struct Lap
    {
        public DateTime time;
        public string name;

        public Lap(DateTime time, string name)
        {
            this.time = time;
            this.name = name;
        }
    }

    /// <summary>
    /// Simple stopwatch classes to support timing of tasks. Can mark individual tasks as a lap.
    /// </summary>
    public class StopWatch
    {
        private DateTime _stopTime;
        private DateTime _startTime;
        private List<Lap> _laps;

        public DateTime StartTime
        {
            get { return _startTime; }
        }

        public DateTime StopTime
        {
            get { return _stopTime; }
        }

        public TimeSpan Elapsed
        {
            get
            {
                return _stopTime - _startTime;
            }
        }

        public StopWatch()
        {
            _startTime = DateTime.MinValue;
            _stopTime = DateTime.MaxValue;
            _laps = new List<Lap>();
        }

        public void Start()
        {
            _startTime = DateTime.Now;
            _laps = new List<Lap>();
            _laps.Add(new Lap(_startTime, "Start"));
        }

        public void Lap(string lapName)
        {
            _laps.Add(new Lap(DateTime.Now, lapName));
        }

        public void Stop()
        {
            _stopTime = DateTime.Now;
            _laps.Add(new Lap(_stopTime, "Stop"));
        }

        public Lap[] GetLaps()
        {
            if (_laps == null)
                return new Lap[0];
            return _laps.ToArray();
        }

        public void LogLaps(string logName)
        {

            Lap[] swatchLaps = GetLaps();
            TimeSpan? span = null;
            DateTime? last = null;

            //If there was only start and stop, just log the time
            if (swatchLaps.Length == 2)
            {
                span = swatchLaps[1].time - swatchLaps[0].time;
                Logger.Log(string.Format("{0}: {1}ms", logName, span.Value.TotalMilliseconds), Logger.Level.Info);
            }
            else
            {
                foreach (var lEntry in swatchLaps)
                {
                    if (last == null)
                    {
                        Logger.Log(string.Format("{0}: {1} - {2}", logName, lEntry.time.ToString("MM/dd/yyyy hh:mm:ss.fff"), lEntry.name), Logger.Level.Info);
                        last = lEntry.time;
                    }
                    else
                    {
                        span = lEntry.time - last;
                        last = lEntry.time;
                        Logger.Log(string.Format("{0}: {1} - {2} Diff: {3}ms", logName, lEntry.time.ToString("MM/dd/yyyy hh:mm:ss.fff"), lEntry.name, span.Value.TotalMilliseconds), Logger.Level.Info);
                    }

                }
            }
        }

    }
}
