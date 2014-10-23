using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI
{
    /// <summary>
    /// A simple rate limiter for the dev.battle.net API. This enforces the API rate limit. All API calls should
    /// await WaitForRateLimit before making their calls.
    /// </summary>
    public static class RateLimiter
    {
        const int MAX_CALLS_PER_SECOND = 10;
        const int MAX_CALLS_PER_MINUTE = 5000;
        static TimeSpan Lifetime = new TimeSpan(0, 1, 0);

        static Queue<DateTime> Calls;

        static RateLimiter()
        {
            Calls = new Queue<DateTime>();
        }

        public async static Task WaitForRateLimit()
        {
            //Continuously delay 1s until under rate limit
            while (GetRatePerMinute() > MAX_CALLS_PER_MINUTE)
                await Task.Delay(1000);

            if (GetRatePerSecond() > MAX_CALLS_PER_SECOND)
                await Task.Delay(1000);
            Cleanup();
            RegisterAPICall();
        }

        private static void RegisterAPICall()
        {
            Calls.Enqueue(DateTime.Now);
        }

        private static void Cleanup()
        {
            while (Calls.Count > 0)
            {
                //Remove all entries older than one minute
                if (Calls.Peek() > DateTime.Now.Subtract(Lifetime))
                    Calls.Dequeue();
                else
                    return; //Cleanup complete
            }
        }

        private static int GetRatePerSecond()
        {
            //Get all calls for the last second
            var a = from call in Calls
                    where call >= DateTime.Now.Subtract(new TimeSpan(0, 0, 1))
                    select call;
            int count = a.Count();
            return count;
        }

        private static int GetRatePerMinute()
        {
            //Get all calls for the last minute
            var a = from call in Calls
                    where call >= DateTime.Now.Subtract(new TimeSpan(0, 1, 0))
                    select call;
            int count = a.Count();
            return count;
        }
    }
}
