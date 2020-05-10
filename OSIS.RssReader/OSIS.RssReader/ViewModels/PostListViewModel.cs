using OSIS.RssReader.Data;
using OSIS.RssReader.Extensions;
using OSIS.RssReader.Repositories;
using OSIS.RssReader.ViewModels.Bases;
using OSIS.RssReader.Web;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace OSIS.RssReader.ViewModels
{
    public class PostListViewModel : BaseListViewModel
    {
        private List<Post> _list;
        private readonly RssRepository _repo = new RssRepository();
        private ObservableCollection<Post> _postsList;

        public ObservableCollection<Post> PostsList
        {
            get => _postsList;
            set
            {
                if(value == _postsList)
                    return;

                _postsList = value;
                OnPropertyChanged(nameof(PostsList));
            }
        }


        public bool ShowSaveForLater;


        public PostListViewModel(bool showLater)
        {
            ShowSaveForLater = showLater;
            //LoadData();
        }

        public override void DeleteItem(int id)
        {
            _repo.DeletePost(id);
            LoadData();
        }


        public async void LoadData(string search = "")
        {
            IsBusy = true;


            PostsList = new ObservableCollection<Post>();
            _list = new List<Post>();

            if (!ShowSaveForLater)
            {
                var sources = _repo.GetSource();

                foreach (var source in sources.Where(source => !string.IsNullOrEmpty(source.SourceUrl)))
                {
                    _list.AddRange(await RssClient.LoadPostsAsync(source.SourceUrl));
                }
            }
            else
            {
                _list = _repo.GetPosts();
            }

            if (!string.IsNullOrEmpty(search))
            {
                _list = _list.Where(l => (l.Title != null && l.Title.Contains(search))).ToList();
            }

            CreateListForUi(_list);

            IsBusy = false;
        }

        public void FilterTeams(string search)
        {
            if (_list == null || _list.Count <= 0)
                return;


            PostsList.RemoveAll();

            var news = _list;
            if (!string.IsNullOrEmpty(search))
                news = _list.Where(l => l.Title != null && l.Title.ToLower().Contains(search.ToLower().Trim())).ToList();

            CreateListForUi(news);
        }

        private void CreateListForUi(IReadOnlyCollection<Post> newList)
        {
            if (newList != null)
            {
                PostsList = new ObservableCollection<Post>(newList);
                ItemNumber = newList.Count;
            }
            else
            {
                ItemNumber = 0;
            }

            if (ItemNumber == 0)
            {
                ShowEmpty = true;
                ShowListView = false;
                ItemNumberText = "No post found";
            }
            else
            {
                ShowEmpty = false;
                ShowListView = true;
                ItemNumberText = ItemNumber == 1 ? "1 post" : $"{ItemNumber} posts";
            }
        }

        public async Task SavePost(Post post)
        {
            if (!_repo.Exists(post.Link))
            {
                post.HtmlPost = await WebHelper.Download(post.Link);
                _repo.SavePost(post);
            }
        }

        public void DeletePost(Post post)
        {
            if (_repo.Exists(post.Link))
            {
                _repo.DeletePost(post.Id);
                _list.Remove(post);
                CreateListForUi(_list);
            }
        }
    }
}