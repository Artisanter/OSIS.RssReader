using SQLite;

namespace OSIS.RssReader.Repositories
{
    public interface ISqLite
    {
        SQLiteConnection GetConnection();
    }
}
