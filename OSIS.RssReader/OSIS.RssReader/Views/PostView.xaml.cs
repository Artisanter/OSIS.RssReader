using System.Diagnostics.CodeAnalysis;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OSIS.RssReader.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [SuppressMessage("ReSharper", "RedundantExtendsListEntry")]
    public partial class PostView : ContentPage
    {
        public PostView()
        {
            InitializeComponent();
        }
    }
}