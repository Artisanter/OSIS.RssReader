using OSIS.RssReader.Data;
using System;
using System.Collections.Generic;

namespace OSIS.RssReader.Repositories
{
    public class RssRepository : IDisposable
    {
        private readonly RssDatabase _db;


        public RssRepository()
        {
            _db = new RssDatabase();
        }


        public void Dispose() { }

        public bool Exists(string link)
        {
            var result = _db.GetItems<Post>(f => f.Link.Contains(link));

            return result.Count != 0;
        }

        #region Post
        public List<Post> GetPosts()
        {
            return _db.GetItems<Post>();
        }

        public Post GetPost(int id)
        {
            return _db.GetItem<Post>(id);
        }

        public int SavePost(Post item)
        {
            return _db.SaveItem(item);
        }

        public void DeletePost(int id)
        {
            _db.DeleteItem<Post>(id);
        }
        #endregion

        #region Source
        public List<Source> GetSource()
        {
            return _db.GetItems<Source>();
        }

        public Source GetSource(int id)
        {
            return _db.GetItem<Source>(id);
        }

        public int SaveSource(Source item)
        {
            return _db.SaveItem(item);
        }

        public int DeleteSource(int id)
        {
            return _db.DeleteItem<Source>(id);
        }
        #endregion
    }
}
