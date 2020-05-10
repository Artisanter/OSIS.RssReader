using SQLite;

namespace OSIS.RssReader.Data
{
    [Table("Source")]
    public class Source : BaseTableRssReader
    {
        public string Title { get; set; }

        public string SourceUrl { get; set; }

        public string ImagePath { get; set; }

        public bool HasImagePath { get; set; }
    }
}
