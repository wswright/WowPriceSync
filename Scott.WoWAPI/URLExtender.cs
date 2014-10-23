using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI
{
    public class URLExtender
    {
        public static string AddParameter(string URL, string newParameter)
        {
            if (URL.Contains("?"))
            {
                //URL already contains parameters
                return string.Format("{0}&{1}", URL, newParameter);
            }
            else
            {
                return string.Format("{0}?{1}", URL, newParameter);
            }
        }
    }
}
