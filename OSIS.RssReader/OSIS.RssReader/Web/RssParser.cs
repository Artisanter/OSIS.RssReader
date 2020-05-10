using OSIS.RssReader.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace OSIS.RssReader.Web
{
    public static class RssParser
    {
        public static List<Post> ParseByXmlDocumentAsync(string xml)
        {
            var document = XDocument.Parse(xml);

            var list = document.Descendants("item")
                .Select(itm => new Post
                {
                    Title = itm.Element("title")?.Value,
                    Description = ReduceString(itm.Element("description")?.Value),
                    Link = itm.Element("link")?.Value,
                    ImageUrl = itm.Element("enclosure")?.Attribute("url")?.Value,
                    PubDate = DateTime.Parse(itm.Element("pubDate")?.Value)
                })
                .ToList();

            return list;
        }

        private static string ReduceString(string content)
        {
            content = StripHtml(content);
            if (content.Length > 200)
                content = content.Substring(0, 200).Trim() + "...";

            return content;
        }

        private static string StripHtml(string input)
        {
            return Regex.Replace(input, "<.*?>", string.Empty);
        }
    }
}
