using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.APIModel.AuctionData
{
    public class AuctionData
    {
        public List<AuctionFile> files { get; set; }
    }

    public class AuctionFile
    {
        public long lastModified { get; set; }
        public string url { get; set; }
    }
}
