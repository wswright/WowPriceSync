using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI
{
    public class RegionInfo
    {
        public enum Region { US, Europe, Korea, Taiwan, China };
        public enum Locale { en_US, es_MX, pt_BR, en_GB, en_ES, fr_FR, ru_RU, de_DE, pt_PT, it_IT, ko_KR, zh_TW, zh_CN };
        private enum Locales_US { en_US, es_MX, pt_BR };
        private enum Locales_Europe { en_GB, en_ES, fr_FR, ru_RU, de_DE, pt_PT, it_IT };
        private enum Locales_Korea { ko_KR };
        private enum Locales_Taiwan { zh_TW };
        private enum Locales_China { zh_CN };

        public Locale locale;
        public Region region;
        public string Host
        {
            get
            {
                return RegionHosts[region];
            }
        }

        private static Dictionary<Region, string> RegionHosts;

        static RegionInfo()
        {
            //Statically create the list of hosts for each region
            RegionHosts = new Dictionary<Region, string>();
            RegionHosts.Add(Region.US, "us.api.battle.net");
            RegionHosts.Add(Region.Europe, "eu.battle.net");
            RegionHosts.Add(Region.Korea, "kr.battle.net");
            RegionHosts.Add(Region.Taiwan, "tw.battle.net");
            RegionHosts.Add(Region.China, "www.battlenet.com.cn");
        }

        public RegionInfo(Region region, Locale locale = Locale.en_US)
        {
            if (!IsLocaleValid(region, locale))
                throw new ArgumentException("Locale invalid with provided region!");

            this.region = region;
            this.locale = locale;
        }

        public static bool IsLocaleValid(Region r, Locale l)
        {
            switch (r)
            {
                case Region.US:
                    return Enum.IsDefined(typeof(Locales_US), l.ToString());
                case Region.Europe:
                    return Enum.IsDefined(typeof(Locales_Europe), l);
                case Region.Korea:
                    return Enum.IsDefined(typeof(Locales_Korea), l);
                case Region.Taiwan:
                    return Enum.IsDefined(typeof(Locales_Taiwan), l);
                case Region.China:
                    return Enum.IsDefined(typeof(Locales_China), l);
                default:
                    return false;
            }
        }
    }
}
