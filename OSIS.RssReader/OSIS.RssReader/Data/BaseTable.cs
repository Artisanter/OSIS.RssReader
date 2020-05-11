using OSIS.RssReader.Repositories;
using SQLite;

namespace OSIS.RssReader.Data
{
    public class BaseTableEntity : ITableEntity
    {
        [PrimaryKey, AutoIncrement]
        [Indexed]
        public int Id { get; set; }
    }
}
