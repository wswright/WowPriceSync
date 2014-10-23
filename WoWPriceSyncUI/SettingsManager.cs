using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWPriceSyncUI
{
    /// <summary>
    /// Static settings class that gives assembly access to config values.
    /// </summary>
    internal static class SettingsManager
    {
        /// <summary>
        /// Your dev.battle.net API Key.
        /// </summary>
        public static string APIKey
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["APIKey"];
                }
                catch (Exception eX)
                {
                    Logger.Log(string.Format("Failed to read APIKey from config! Message: {0}", eX.Message), Logger.Level.Error);
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// The path to the item icons.
        /// </summary>
        public static string ImageFolder
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["ImageFolder"];
                }
                catch (Exception eX)
                {
                    Logger.Log(string.Format("Failed to read ImageFolder from config! Message: {0}", eX.Message), Logger.Level.Error);
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Determines if the application should try to sync icons from the ImageFolder with the Database.
        /// </summary>
        public static bool DoIconSync
        {
            get
            {
                bool doIt;
                if (bool.TryParse(ConfigurationManager.AppSettings["DoIconSync"], out doIt))
                    return doIt;
                return true;
            }
        }

        /// <summary>
        /// The LastModified time of the AuctionData.
        /// </summary>
        public static long LastModified
        {
            get
            {
                return _lastModified;
            }

            set
            {
                _lastModified = value;
            }
        }
        private static long _lastModified = 0L;
    }
}
