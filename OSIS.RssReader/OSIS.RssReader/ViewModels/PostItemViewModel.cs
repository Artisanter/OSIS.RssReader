using OSIS.RssReader.Data;
using OSIS.RssReader.ViewModels.Bases;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace OSIS.RssReader.ViewModels
{
    public class PostItemViewModel : BaseForViewModel
    {
        private string _description;
        private string _category;
        private string _newsSource;
        private string _link;
        private string _imageUrl;
        private DateTime _pubDate;

        public PostItemViewModel(Post post, bool saveOnDatabase = true)
        {
            SaveOnDatabase = saveOnDatabase;

            IsBusy = true;
            LoadData(post);
            IsBusy = false;
        }


        public void LoadData(Post post)
        {
            if (post == null)
                return;

            Title = post.Title;
            Description = post.Description;
            NewsSource = post.NewsSource;
            Link = post.Link;
            ImageUrl = post.ImageUrl;
            PubDate = post.PubDate;
        }

        public string Description
        {
            get => _description;
            set => OnPropertyChanging(nameof(Description), ref _description, value);
        }

        public string Category
        {
            get => _category;
            set => OnPropertyChanging(nameof(Category), ref _category, value);
        }

        public string NewsSource
        {
            get => _newsSource;
            set => OnPropertyChanging(nameof(NewsSource), ref _newsSource, value);
        }
        public string Link
        {
            get => _link;
            set => OnPropertyChanging(nameof(Link), ref _link, value);
        }

        public string ImageUrl
        {
            get => _imageUrl;
            set => OnPropertyChanging(nameof(ImageUrl), ref _imageUrl, value);
        }

        public DateTime PubDate
        {
            get => _pubDate;
            set => OnPropertyChanging(nameof(PubDate), ref _pubDate, value);
        }

        private ICommand _saveCommand;

        public ICommand SavePostItem => _saveCommand ?? (_saveCommand = new Command(() => ExecuteSavePostCommand()));

        private void ExecuteSavePostCommand()
        {
            IsBusy = true;
            SavePostOnDB();
            IsBusy = false;
        }

        private void SavePostOnDB()
        {
            var post = new Post();
            if (Id != 0)
            {
                post = Repo.GetPost(Id);
            }
            post.Title = Title;
            post.Description = Description;
            post.NewsSource = NewsSource;
            post.Link = Link;
            post.ImageUrl = ImageUrl;
            post.PubDate = PubDate;

            if (SaveOnDatabase)
            {
                Id = Repo.SavePost(post);
            }
        }
    }
}
