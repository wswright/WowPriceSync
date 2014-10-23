using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace WoWPriceSyncUI
{
    public static class Logger
    {
        public static readonly object ConsoleLock = new object();
        public enum Level { Debug, Info, Warning, Error };

        public static Level DisplayLevel = Level.Debug;

        public delegate void OnLogEvent(string message, Level lvl);
        public static event OnLogEvent OnLog;

        public static void Log(string message, Level lvl = Level.Info)
        {
            if (lvl < DisplayLevel)
                return;

            lock (ConsoleLock)
            {
                Console.WriteLine(string.Format("[{0}] - {1}", DateTime.Now.ToShortTimeString(), message));
                Console.Out.Flush();
            }
            OnLogEvent tmp = OnLog;
            if (tmp != null)
                foreach (OnLogEvent olEvent in tmp.GetInvocationList())
                    olEvent.BeginInvoke(string.Format("[{0}] - {1}", DateTime.Now.ToShortTimeString(), message), lvl, EndAsync_OnLogEvent, null);

        }

        private static void EndAsync_OnLogEvent(IAsyncResult iar)
        {
            var ar = (AsyncResult)iar;
            var invokedMethod = (OnLogEvent)ar.AsyncDelegate;

            try
            {
                invokedMethod.EndInvoke(iar);
            }
            catch
            {
                Console.WriteLine("An event listener went KABOOOM!");
            }
        }
    }
}
