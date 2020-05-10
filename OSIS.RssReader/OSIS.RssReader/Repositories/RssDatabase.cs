using OSIS.RssReader.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xamarin.Forms;

namespace OSIS.RssReader.Repositories
{
    public class RssDatabase
    {
        private readonly SQLiteConnection _database;
        private static readonly object Locker = new object();


        public RssDatabase()
        {
            _database = DependencyService.Get<ISqLite>().GetConnection();
            InitDatabase();
        }


        public void InitDatabase()
        {
            lock (Locker)
            {
                if (_database == null)
                    return;

                _database.CreateTable<Post>();
                _database.CreateTable<Source>();
            }
        }

        public List<T> GetItems<T>() where T : ITableEntityRssReader, new()
        {
            lock (Locker)
            {
                return  _database.Table<T>().ToList();
            }
        }

        public List<T> GetItems<T>(Expression<Func<T, bool>> func) where T : ITableEntityRssReader, new()
        {
            lock (Locker)
            {
                return _database.Table<T>().Where(func).ToList();
            }
        }
        public T GetItem<T>(int id) where T : ITableEntityRssReader, new()
        {
            lock (Locker)
            {
                return _database.Table<T>().FirstOrDefault(x => x.Id == id);
            }
        }

        public int SaveItem<T>(T item) where T : ITableEntityRssReader
        {
            lock (Locker)
            {
                if (item.Id != 0)
                {
                    _database.Update(item);
                    return item.Id;
                }

                return _database.Insert(item);
            }
        }

        public int DeleteItem<T>(int id) where T : ITableEntityRssReader, new()
        {
            lock (Locker)
            {
                return _database.Delete<T>(id);
            }
        }
    }
}