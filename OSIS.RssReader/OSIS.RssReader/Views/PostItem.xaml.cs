using System.Diagnostics.CodeAnalysis;
using OSIS.RssReader.Data;
using OSIS.RssReader.ViewModels;
using Xamarin.Forms;

namespace OSIS.RssReader.Views
{
    [SuppressMessage("ReSharper", "RedundantExtendsListEntry")]
    public partial class PostItem : ContentPage
    {
        public PostItem()
        {
            InitializeComponent();
        }


        public PostItem(Post post)
        {
            InitializeComponent();
            BindingContext = new PostItemViewModel(post);
        }

    }
}