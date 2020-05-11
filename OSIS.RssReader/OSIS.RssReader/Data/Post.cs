using SQLite;
using System;

namespace OSIS.RssReader.Data
{
    [Table("Post")]
    public class Post : BaseTableEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string NewsSource { get; set; }

        public string Link { get; set; }

        public string ImageUrl { get; set; }

        public DateTime PubDate { get; set; }

        public string HtmlPost { get; set; }

        [Ignore] public bool Saved => Id != 0;

        [Ignore] public bool NotSaved => Id == 0;
    }
}
