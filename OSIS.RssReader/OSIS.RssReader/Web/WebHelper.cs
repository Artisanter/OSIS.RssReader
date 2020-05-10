using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace OSIS.RssReader.Web
{
    public static class WebHelper
    {
        public static async Task<string> Download(string url)
        {
            try
            {
                return await new HttpClient().GetStringAsync(new Uri(url));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return string.Empty;
        }
    }
}
