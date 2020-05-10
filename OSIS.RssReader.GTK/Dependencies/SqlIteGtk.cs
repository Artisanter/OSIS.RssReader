using OSIS.RssReader.Repositories;
using System.IO;
using OSIS.RssReader.GTK.Dependencies;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqLiteGtk))]
namespace OSIS.RssReader.GTK.Dependencies
{
    public class SqLiteGtk : ISqLite
    {
        private const string DatabaseName = "RSSReader.db3";

        public SQLiteConnection GetConnection()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), DatabaseName);
            var conn = new SQLiteConnection(path);

            return conn;
        }
    }
}