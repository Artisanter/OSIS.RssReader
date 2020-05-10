using System;
using System.IO;
using OSIS.RssReader.Droid.Dependencies;
using OSIS.RssReader.Repositories;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqLiteGtk))]
namespace OSIS.RssReader.Droid.Dependencies
{
    public class SqLiteGtk : ISqLite
    {
        private const string DatabaseName = "RSSReader.db3";

        public SQLiteConnection GetConnection()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), DatabaseName);
            var conn = new SQLiteConnection(path);

            return conn;
        }
    }
}