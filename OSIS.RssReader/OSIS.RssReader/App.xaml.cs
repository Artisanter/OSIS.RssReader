using System.Diagnostics.CodeAnalysis;
using OSIS.RssReader.Repositories;
using OSIS.RssReader.ViewModels.Menu;
using Xamarin.Forms;

namespace OSIS.RssReader
{
    [SuppressMessage("ReSharper", "RedundantExtendsListEntry")]
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new RootPage();
        }


        protected override void OnStart()
        {
            var db = new RssDatabase();
            db.InitDatabase();
        }
    }
}