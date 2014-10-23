using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI
{
    public static class DataUtils
    {
        public static DateTime LongToDateTime(long jsonTime)
        {
            DateTime calcTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return calcTime.AddSeconds(jsonTime/1000);
        }
    }
}
