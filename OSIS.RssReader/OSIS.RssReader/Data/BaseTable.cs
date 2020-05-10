using System;
using OSIS.RssReader.Repositories;
using SQLite;

namespace OSIS.RssReader.Data
{
    public class BaseTableRssReader : ITableEntity
    {
        [PrimaryKey, AutoIncrement]
        [Indexed]
        public int Id { get; set; } = 0;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;
    }
}
