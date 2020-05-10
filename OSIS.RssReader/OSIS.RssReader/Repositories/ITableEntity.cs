using System;

namespace OSIS.RssReader.Repositories
{
    public interface ITableEntity
    {
        int Id { get; set; }

        bool IsDeleted { get; set; }

        DateTime UpdatedDate { get; set; }
    }
}
