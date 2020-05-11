using SQLite;

namespace OSIS.RssReader.Data
{
    [Table("Source")]
    public class Source : BaseTableEntity
    {
        public string Title { get; set; }

        public string SourceUrl { get; set; }
    }
}
