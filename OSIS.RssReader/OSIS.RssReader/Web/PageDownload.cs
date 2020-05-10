using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace OSIS.RssReader.Web
{
    public static class PageDownload
    {
        public static async Task<string> Start(string url)
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
