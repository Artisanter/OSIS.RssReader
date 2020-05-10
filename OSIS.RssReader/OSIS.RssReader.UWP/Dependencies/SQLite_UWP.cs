using System.IO;
using Windows.Storage;
using OSIS.RssReader.Repositories;
using OSIS.RssReader.UWP.Dependencies;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqLiteUwp))]
namespace OSIS.RssReader.UWP.Dependencies
{
    public class SqLiteUwp : ISqLite
    {
        private const string DatabaseName = "RSSReader.db3";

        public SQLiteConnection GetConnection()
        {
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, DatabaseName);
            var conn = new SQLiteConnection(path);

            return conn;
        }
    }
}