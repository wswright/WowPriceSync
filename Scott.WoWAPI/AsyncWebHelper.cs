using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI
{
    public class AsyncWebHelper
    {
        public static async Task<string> GetAuthenticatedPage(string URL, string APIKey)
        {
            string API_URL = URLExtender.AddParameter(URL, "apikey=" + APIKey);
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(API_URL);
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                        return string.Empty;
                    return (await response.Content.ReadAsStringAsync());
                } catch(Exception eX)
                {
                    Console.WriteLine(string.Format("Error fetching page! URL: {0} Message: {1}", URL, eX.Message));
                    return null;
                }
            }
        }

        public static async Task<string> GetPage(string URL)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(URL);
                    return (await response.Content.ReadAsStringAsync());
                }
                catch (Exception eX)
                {
                    Console.WriteLine(string.Format("Error fetching page! URL: {0} Message: {1}", URL, eX.Message));
                    return null;
                }
            }
        }
    }
}
