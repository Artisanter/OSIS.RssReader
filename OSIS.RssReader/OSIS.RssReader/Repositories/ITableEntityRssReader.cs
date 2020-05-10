using System;

namespace OSIS.RssReader.Repositories
{
    public interface ITableEntityRssReader
    {
        int Id { get; set; }

        bool IsDeleted { get; set; }

        DateTime UpdatedDate { get; set; }
    }
}
