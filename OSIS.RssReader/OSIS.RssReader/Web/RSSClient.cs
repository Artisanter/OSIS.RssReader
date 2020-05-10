using OSIS.RssReader.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OSIS.RssReader.Web
{
    public static class RssClient
    {
        public static async Task<List<Post>> LoadPostsAsync(string url)
        {
            try
            {
                var xml = await CallUrlAsync(url);

                return xml is null ? new List<Post>() : RssParser.ParseByXmlDocumentAsync(xml);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return new List<Post>();
            }
        }


        private static async Task<string> CallUrlAsync(string url)
        {
            using var webClient = new HttpClient();
            var xmlUrl = new Uri(url);

            var response = await webClient.GetAsync(xmlUrl);
            if (!response.IsSuccessStatusCode)
                return null;

            var xml = await response.Content.ReadAsStringAsync();

            return xml;
        }
    }
}
